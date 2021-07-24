using System;
using System.Collections.Generic;
using System.Text;
using IgniteVMS.Entities;
using System.Threading.Tasks;

namespace IgniteVMS.Repositories.Contracts
{
    public interface IVolunteerRepository
    {
        // This is an example
        public Task<IEnumerable<int>> GetAllVolunteerIDs();
    }
}
