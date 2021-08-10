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
        // This is an example
        public Task<IEnumerable<Volunteer>> GetAllVolunteers();
    }
}
