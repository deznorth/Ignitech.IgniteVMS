using IgniteVMS.Entities.Volunteers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IgniteVMS.Services.Contracts
{
    public interface IVolunteerService
    {
        public Task<IEnumerable<SimplifiedVolunteer>> GetAllVolunteers();
        public Task<Volunteer> GetVolunteerByID(int volunteerId);
        public Task<Volunteer> CreateVolunteer(VolunteerCreateRequest request);
        public Task DeleteVolunteer(int volunteerId);
    }
}
