using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Autofac;
using IgniteVMS.DataAccess;
using IgniteVMS.DataAccess.Modules;
using IgniteVMS.Repositories;
using IgniteVMS.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace IgniteVMS
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            LogStartup();

            services.AddMvc();

            services
                .AddHttpContextAccessor()
                .AddControllersWithViews();

            // Http Clients
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Serilog Logging
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithProperty("App Name", "IgniteVMS")
                .WriteTo.Console()
                .CreateLogger();

            void LogStartup()
            {
                var pid = Process.GetCurrentProcess().Id;
                var name = GetType().Namespace;
                Console.WriteLine("[{0}] service started as pid [{1}]", name, pid);
            }

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "IgniteVMS API",
                        Description = "API for the IgniteVMS Pre-Semester Assignment",
                        Version = "v1"
                    });

                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });
        }

        // Here we'll register repositories and services
        public void ConfigureContainer(ContainerBuilder builder)
        {
            var connectionStringResolver = new ConnectionStringResolver
            {
                DB_HOST = configuration.GetValue<string>("DB_HOST"),
                DB_PORT = configuration.GetValue<string>("DB_PORT"),
                DB_NAME = configuration.GetValue<string>("DB_NAME"),
                DB_USER = configuration.GetValue<string>("DB_USER"),
                DB_PASS = configuration.GetValue<string>("DB_PASS")
            };

            // Modules
            builder.RegisterModule(new ModuleBuilder()
                .UseConnectionOwner(connectionStringResolver)
                .Build());

            // Repositories
            builder.RegisterType<VolunteerRepository>().AsImplementedInterfaces().SingleInstance();

            // Services
            builder.RegisterType<VolunteerService>().AsImplementedInterfaces().SingleInstance();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var forwardedHeadersOptions = new ForwardedHeadersOptions
            {
                RequireHeaderSymmetry = false,
                ForwardedHeaders = ForwardedHeaders.All
            };
            forwardedHeadersOptions.KnownNetworks.Clear();
            forwardedHeadersOptions.KnownProxies.Clear();

            app.UseHttpsRedirection();
            
            app
                .UseStaticFiles()
                .UseRouting();

            app
                .UseAuthentication()
                .UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "IgniteVMS API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Home");
            });

            app.UseCors(policy =>
            {
                var allowedOrigins = configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? new string[] { };
                policy.WithOrigins(allowedOrigins);
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
            });
        }
    }
}
