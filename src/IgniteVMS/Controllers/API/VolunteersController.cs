using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IgniteVMS.Entities.Volunteers;
using IgniteVMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

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
        /// Gets a list of all volunteers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, null, typeof(IEnumerable<Volunteer>))]
        public async Task<IActionResult> GetAllVolunteers()
        {
            try
            {
                var volunteers = await volunteerService.GetAllVolunteers();
                return Ok(volunteers);
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
