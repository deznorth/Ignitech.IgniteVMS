using System;
using System.Collections.Generic;
using System.Text;
using IgniteVMS.Entities;
using System.Threading.Tasks;
using IgniteVMS.Entities.Volunteers;

namespace IgniteVMS.Repositories.Contracts
{
    public interface IVolunteerRepository
    {
        public Task<IEnumerable<Volunteer>> GetAllVolunteers();
        public Task<Volunteer> GetVolunteerByID(int volunteerId);
        public Task<IEnumerable<Qualification>> GetVolunteerQualifications(int volunteerId);
        public Task<IEnumerable<AvailabilityTime>> GetAvailabilityTimes(int volunteerId);

        public Task<Volunteer> CreateVolunteer(VolunteerCreateRequest request);
        public Task DeleteVolunteer(int volunteerId);
    }
}
