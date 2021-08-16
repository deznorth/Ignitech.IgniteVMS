using IgniteVMS.Entities.Opportunities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteVMS.Repositories.Contracts
{
    public interface IOpportunityRepository
    {
        public Task<IEnumerable<Opportunity>> GetAllOpportunities();
    }
}
