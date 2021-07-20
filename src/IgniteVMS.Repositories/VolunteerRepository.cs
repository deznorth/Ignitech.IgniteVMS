using IgniteVMS.DataAccess;
using IgniteVMS.Repositories.Contracts;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Data.Entity;

namespace IgniteVMS.Repositories
{
    public class VolunteerRepository : IVolunteerRepository
    {
        private readonly ILogger<VolunteerRepository> logger;
        private readonly PostgreSqlContext dbContext;

        public VolunteerRepository(
            ILogger<VolunteerRepository> logger,
            PostgreSqlContext dbContext
        )
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<int>> GetAllVolunteerIDs()
        {
            return dbContext.Volunteers.FromSqlRaw("SELECT * FROM dbo.\"Volunteers\"").Select(v => v.VolunteerID).ToList();
        }
    }
}
