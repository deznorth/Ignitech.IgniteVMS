using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IgniteVMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IgniteVMS.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : Controller
    {
        private readonly ILogger<ExampleController> logger;
        private readonly IVolunteerService volunteerService;

        public ExampleController(
            ILogger<ExampleController> logger,
            IVolunteerService volunteerService
        )
        {
            this.logger = logger;
            this.volunteerService = volunteerService;
        }

        /// <summary>
        /// This is an example endpoint
        /// </summary>
        /// <returns>A hello world string</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllVolunteerIDs()
        {
            try
            {
                var volunteerIDs = await volunteerService.GetAllVolunteerIDs();
                return Ok(volunteerIDs);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
