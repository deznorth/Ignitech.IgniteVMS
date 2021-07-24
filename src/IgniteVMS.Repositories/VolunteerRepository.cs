using IgniteVMS.DataAccess.Contracts;
using IgniteVMS.Entities;
using IgniteVMS.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;

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
                var result = (await conn.QueryAsync<Volunteer>("SELECT * FROM dbo.\"Volunteers\"")).Select(v => v.VolunteerID).ToList();
                return result;
            });
        }
    }
}
