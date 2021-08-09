using System;
using System.Threading.Tasks;
using IgniteVMS.Entities;
using IgniteVMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IgniteVMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetricsController : Controller
    {
        private readonly ILogger<MetricsController> logger;
        private readonly IMetricsService metricsService;

        public MetricsController(
            ILogger<MetricsController> logger,
            IMetricsService metricsService
        )
        {
            this.logger = logger;
            this.metricsService = metricsService;
        }

        /// <summary>
        /// Gets volunteer stats and up to 5 upcoming opportunities
        /// </summary>
        /// <example>test</example>
        [HttpGet]
        [ProducesResponseType(typeof(MetricsResponse), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetMetrics()
        {
            try
            {
                var metrics = await metricsService.GetMetrics();
                return Ok(metrics);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
