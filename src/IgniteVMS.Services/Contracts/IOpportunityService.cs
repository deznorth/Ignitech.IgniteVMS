using IgniteVMS.Entities.Opportunities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteVMS.Services.Contracts
{
    public interface IOpportunityService
    {
        public Task<IEnumerable<Opportunity>> GetAllOpportunities();
    }
}
