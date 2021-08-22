using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IgniteVMS.Entities.Volunteers;
using IgniteVMS.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Npgsql;
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
        [SwaggerResponse(200, null, typeof(IEnumerable<SimplifiedVolunteer>))]
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

        /// <summary>
        /// Gets a volunteer by ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{volunteerId}")]
        [SwaggerResponse(200, null, typeof(Volunteer))]
        [SwaggerResponse(404, null)]
        public async Task<IActionResult> GetVolunteerByID(int volunteerId)
        {
            try
            {
                var volunteers = await volunteerService.GetVolunteerByID(volunteerId);
                return Ok(volunteers);
            }
            catch (Exception e)
            {
                return new NotFoundResult();
            }
        }

        /// <summary>
        /// Creates a volunteer
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerResponse(201, null, typeof(Volunteer))]
        [SwaggerResponse(409, "The username was already taken")]
        [SwaggerResponse(400, "One or more database checks failed")]
        [SwaggerResponse(500, "An unexpected error ocurred")]
        public async Task<IActionResult> CreateVolunteer([FromBody] VolunteerCreateRequest request)
        {
            try
            {
                var volunteer = await volunteerService.CreateVolunteer(request);
                return new CreatedAtActionResult(nameof(GetVolunteerByID), "Volunteers", new { volunteerId = volunteer.VolunteerID }, volunteer);
            }
            catch (PostgresException e)
            {
                switch (e.SqlState)
                {
                    case PostgresErrorCodes.UniqueViolation:
                        return new ConflictResult();
                    case PostgresErrorCodes.CheckViolation:
                        return new BadRequestResult();
                    default:
                        return new StatusCodeResult(500);
                }
                
            }
        }

        /// <summary>
        /// Deletes a volunteer by ID
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{volunteerId}")]
        [SwaggerResponse(204, null)]
        public async Task<IActionResult> DeleteVolunteerByID(int volunteerId)
        {
            try
            {
                await volunteerService.DeleteVolunteer(volunteerId);
                return new NoContentResult();
            }
            catch (Exception e)
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
