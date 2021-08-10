using IgniteVMS.Entities.Volunteers;
using IgniteVMS.Repositories.Contracts;
using IgniteVMS.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IgniteVMS.Services
{
    public class VolunteerService : IVolunteerService
    {
        private readonly ILogger<VolunteerService> logger;
        private readonly IVolunteerRepository volunteerRepository;

        public VolunteerService(
            ILogger<VolunteerService> logger,
            IVolunteerRepository volunteerRepository
        )
        {
            this.logger = logger;
            this.volunteerRepository = volunteerRepository;
        }
        public async Task<IEnumerable<Volunteer>> GetAllVolunteers()
        {
            try
            {
                return await volunteerRepository.GetAllVolunteers();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error retrieving all volunteers");
                throw e;
            }
        }
    }
}
