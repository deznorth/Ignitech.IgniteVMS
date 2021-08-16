using System;
using System.Text;
using System.Threading.Tasks;
using IgniteVMS.Entities;
using IgniteVMS.Services.Contracts;
using Microsoft.Extensions.Logging;
using IgniteVMS.Repositories.Contracts;
using IgniteVMS.Entities.Constants;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using IgniteVMS.Services.Utilities;

namespace IgniteVMS.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> logger;
        private readonly IAuthRepository authRepository;
        private readonly string jwtkey;
        private readonly string jwtissuer;

        public AuthService(
            ILogger<AuthService> logger,
            IAuthRepository authRepository,
            string jwtkey,
            string jwtissuer
        )
        {
            this.logger = logger;
            this.authRepository = authRepository;
            this.jwtkey = jwtkey;
            this.jwtissuer = jwtissuer;
        }

        public async Task<LoginResponse> AuthenticateUser(LoginRequest request)
        {
            try
            {
                // Must hash password before comparing it against the DB
                var updatedRequest = new LoginRequest
                {
                    Username = request.Username,
                    Password = PasswordHasher.GetHashedPassword(request.Password)
                };

                var user = await authRepository.AuthenticateUser(updatedRequest);

                // Only allow administrators to log into the app
                if (user != null && user.UserRole == UserRoles.Administrator)
                {
                    return new LoginResponse
                    {
                        Jwt = GenerateJSONWebToken(user),
                        CurrentUser = user.ToUserResponse()
                    };
                } else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                logger.LogError(e, $"Error authenticating the user \"{request.Username}\"");
                throw e;
            }
        }

        public async Task<UserResponse> GetUserByID(int userId)
        {
            try
            {
                var user = await authRepository.GetUserByID(userId);
                return user;
                
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error retrieving user by ID");
                throw e;
            }
        }

        public async Task<UserResponse> CreateUser(CreateUserRequest request)
        {
            try
            {
                // Must hash password before saving it to the DB
                var userTemplate = new User
                {
                    Username = request.Username,
                    Password = PasswordHasher.GetHashedPassword(request.Password),
                    UserRole = request.isAdmin ? UserRoles.Administrator : UserRoles.Volunteer
                };

                var user = await authRepository.SaveUser(userTemplate);

                return user;
            }
            catch (Exception e)
            {
                logger.LogError(e, $"Error creating the user \"{request.Username}\"");
                throw e;
            }
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtkey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("UserID", userInfo.UserID.ToString()),
                new Claim("Username", userInfo.Username),
                new Claim("Role", userInfo.UserRole)
            };

            var token = new JwtSecurityToken(jwtissuer,
              null,
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
