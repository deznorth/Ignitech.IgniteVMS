using IgniteVMS.Entities;
using IgniteVMS.Entities.Opportunities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IgniteVMS.Repositories.Contracts
{
    public interface IMetricsRepository
    {
        public Task<MetricsResponse> GetCounts();
        public Task<IEnumerable<Opportunity>> GetUpcomingOpportunities();
    }
}
