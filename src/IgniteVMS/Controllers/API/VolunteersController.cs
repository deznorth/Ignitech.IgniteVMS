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
    public class VolunteersController : Controller
    {
        private readonly ILogger<VolunteersController> logger;
        private readonly IVolunteerService volunteerService;

        public VolunteersController(
            ILogger<VolunteersController> logger,
            IVolunteerService volunteerService
        )
        {
            this.logger = logger;
            this.volunteerService = volunteerService;
        }

        /// <summary>
        /// This is an example endpoint
        /// </summary>
        /// <returns>All volunteer IDs</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllVolunteerIDs()
        {
            // This is an example, remove this endpoint when you create the real ones.
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
