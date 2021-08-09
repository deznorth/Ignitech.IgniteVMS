using IgniteVMS.Entities;
using System.Threading.Tasks;

namespace IgniteVMS.Services.Contracts
{
    public interface IMetricsService
    {
        public Task<MetricsResponse> GetMetrics();
    }
}
