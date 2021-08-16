using IgniteVMS.Entities.Opportunities;
using IgniteVMS.Repositories.Contracts;
using IgniteVMS.Services.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteVMS.Services
{
    public class OpportunityService : IOpportunityService
    {
        private readonly ILogger<OpportunityService> logger;
        private readonly IOpportunityRepository opportunityRepository;

        public OpportunityService(
            ILogger<OpportunityService> logger,
            IOpportunityRepository opportunityRepository
        )
        {
            this.logger = logger;
            this.opportunityRepository = opportunityRepository;
        }
        public async Task<IEnumerable<Opportunity>> GetAllOpportunities()
        {
            try
            {
                return await opportunityRepository.GetAllOpportunities();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Error retrieving all opportunities");
                throw e;
            }
        }
    }
}
