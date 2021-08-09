using IgniteVMS.Repositories.Contracts;
using IgniteVMS.Entities;
using IgniteVMS.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IgniteVMS.Services
{
    public class MetricsService : IMetricsService
    {
        private readonly ILogger<MetricsService> logger;
        private readonly IMetricsRepository metricsRepository;

        public MetricsService(
            ILogger<MetricsService> logger,
            IMetricsRepository metricsRepository
        )
        {
            this.logger = logger;
            this.metricsRepository = metricsRepository;
        }
        public async Task<MetricsResponse> GetMetrics()
        {
            try
            {
                var response = await metricsRepository.GetCounts();
                var upcomingOpportunities = await metricsRepository.GetUpcomingOpportunities();
                response.UpcomingOpportunities = upcomingOpportunities;
                return response;
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error retrieving metrics");
                throw e;
            }
        }
    }
}
