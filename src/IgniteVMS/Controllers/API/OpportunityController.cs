using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IgniteVMS.Services;
using IgniteVMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace IgniteVMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunityController : Controller
    {
        private readonly ILogger<OpportunityController> logger;
        private readonly IOpportunityService opportunityService;

        public OpportunityController(
            ILogger<OpportunityController> logger,
            IOpportunityService opportunityService
        )
        {
            this.logger = logger;
            this.opportunityService = opportunityService;
        }

        /// <summary>
        /// Gets a list of all opportunities
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, null, typeof(IEnumerable<int>))]
        public async Task<IActionResult> GetAllOpportunities()
        {
            try
            {
                var opportunity = await opportunityService.GetAllOpportunities();
                return Ok(opportunity);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }

    }
}
