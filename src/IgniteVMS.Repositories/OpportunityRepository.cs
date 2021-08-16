using Dapper;
using IgniteVMS.DataAccess.Constants;
using IgniteVMS.DataAccess.Contracts;
using IgniteVMS.Entities.Opportunities;
using IgniteVMS.Entities.Volunteers;
using IgniteVMS.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IgniteVMS.Repositories
{
    public class OpportunityRepository : IOpportunityRepository
    {
        private readonly ILogger<OpportunityRepository> logger;
        private readonly IConnectionOwner dbConnectionOwner;

        public OpportunityRepository(
            ILogger<OpportunityRepository> logger,
            IConnectionOwner dbConnectionOwner
        )
        {
            this.logger = logger;
            this.dbConnectionOwner = dbConnectionOwner;
        }

        public async Task<IEnumerable<Opportunity>> GetAllOpportunities()
        {
            return await dbConnectionOwner.Use(conn =>
            {
                var query = @$"
                    SELECT *
                    FROM {DbTables.Opportunities} v
                ";

                var result = conn.QueryAsync<Opportunity>(query);
                return result;
            });
        }
    }
}
