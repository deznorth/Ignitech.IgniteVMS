using IgniteVMS.DataAccess.Contracts;
using IgniteVMS.Entities;
using IgniteVMS.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using System.Linq;
using IgniteVMS.DataAccess.Constants;
using IgniteVMS.Entities.Volunteers;

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

        public Task<IEnumerable<Volunteer>> GetAllVolunteers()
        {
            return dbConnectionOwner.Use( conn =>
            {
                var query = @$"
                    SELECT *
                    FROM {DbTables.Volunteers} v
                ";

                var result = conn.QueryAsync<Volunteer>(query);
                return result;
            });
        }
    }
}
