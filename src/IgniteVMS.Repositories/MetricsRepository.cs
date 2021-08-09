using IgniteVMS.DataAccess.Contracts;
using IgniteVMS.Entities;
using IgniteVMS.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using IgniteVMS.DataAccess.Constants;
using IgniteVMS.Entities.Opportunities;

namespace IgniteVMS.Repositories
{
    public class MetricsRepository : IMetricsRepository
    {
        private readonly ILogger<MetricsRepository> logger;
        private readonly IConnectionOwner dbConnectionOwner;

        public MetricsRepository(
            ILogger<MetricsRepository> logger,
            IConnectionOwner dbConnectionOwner
        )
        {
            this.logger = logger;
            this.dbConnectionOwner = dbConnectionOwner;
        }

        public Task<MetricsResponse> GetCounts()
        {
            return dbConnectionOwner.Use(conn =>
            {
                var query = @$"
                    SELECT
	                    COUNT(*) FILTER (WHERE ""Approved"" IS NULL) AS ""PendingVolunteers"",
                        COUNT(*) FILTER(WHERE ""Approved"" = 1::boolean) AS ""ApprovedVolunteers"",
	                    COUNT(*) FILTER(WHERE ""Approved"" = 0::boolean) AS ""DeniedVolunteers""
                    FROM {DbTables.Volunteers} v
                ";

                var result = conn.QueryFirstOrDefaultAsync<MetricsResponse>(query);
                return result;
            });
        }
        public Task<IEnumerable<Opportunity>> GetUpcomingOpportunities()
        {
            return dbConnectionOwner.Use(conn =>
            {
                var query = @$"
                    SELECT *
                    FROM {DbTables.Opportunities} o
                    WHERE ""EndsAt"" > NOW()
                    ORDER BY ""StartsAt"" ASC
                    LIMIT 5
                ";

                return conn.QueryAsync<Opportunity>(query);
            });
        }
    }
}
