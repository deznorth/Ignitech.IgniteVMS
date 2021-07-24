using IgniteVMS.DataAccess.Contracts;
using IgniteVMS.Entities;
using IgniteVMS.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using IgniteVMS.DataAccess.Constants;

namespace IgniteVMS.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ILogger<VolunteerRepository> logger;
        private readonly IConnectionOwner dbConnectionOwner;

        public VolunteerRepository(
            ILogger<VolunteerRepository> logger,
            IConnectionOwner dbConnectionOwner
        )
        {
            this.logger = logger;
            this.dbConnectionOwner = dbConnectionOwner;
        }

        public async Task<IEnumerable<int>> GetAllVolunteerIDs()
        {
            return await dbConnectionOwner.Use(async conn =>
            {
                var query = @$"
                    SELECT v.""VolunteerID""
                    FROM {DbTables.Volunteers} v
                ";

                var result = (await conn.QueryAsync<int>(query)).ToList();
                return result;
            });
        }
    }
}
