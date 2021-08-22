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
        private readonly IAuthService authService;
        private readonly IVolunteerRepository volunteerRepository;

        public VolunteerService(
            ILogger<VolunteerService> logger,
            IAuthService authService,
            IVolunteerRepository volunteerRepository
        )
        {
            this.logger = logger;
            this.authService = authService;
            this.volunteerRepository = volunteerRepository;
        }
        public async Task<IEnumerable<SimplifiedVolunteer>> GetAllVolunteers()
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

        public async Task<Volunteer> GetVolunteerByID(int volunteerId)
        {
            try
            {
                var volunteer = await volunteerRepository.GetVolunteerByID(volunteerId);
                volunteer.User = await authService.GetUserByID(volunteer.UserID);
                volunteer.VolunteerQualifications = await volunteerRepository.GetVolunteerQualifications(volunteerId);
                volunteer.AvailabilityTimes = await volunteerRepository.GetAvailabilityTimes(volunteerId);

                return volunteer;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error retrieving a volunteer by ID");
                throw e;
            }
        }

        public async Task<Volunteer> CreateVolunteer(VolunteerCreateRequest request)
        {
            try
            {
                var volunteer = await volunteerRepository.CreateVolunteer(request);
                return volunteer;
            } catch (Exception e)
            {
                logger.LogError(e, "Error creating a volunteer");
                throw e;
            }
        }

        public async Task DeleteVolunteer(int volunteerId)
        {
            try
            {
                await volunteerRepository.DeleteVolunteer(volunteerId);
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error deleting a volunteer");
                throw e;
            }
        }
    }
}
