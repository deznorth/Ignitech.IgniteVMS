using IgniteVMS.Entities.Volunteers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteVMS.Services.Contracts
{
    public interface IVolunteerService
    {
        public Task<IEnumerable<Volunteer>> GetAllVolunteers();
        public Task<Volunteer> GetVolunteerByID(int volunteerId);
        public Task<Volunteer> CreateVolunteer(VolunteerCreateRequest request);
    }
}
