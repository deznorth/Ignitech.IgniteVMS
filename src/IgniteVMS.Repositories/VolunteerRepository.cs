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

        public async Task<IEnumerable<Volunteer>> GetAllVolunteers()
        {
            return await dbConnectionOwner.Use(conn =>
            {
                var query = @$"
                    SELECT *
                    FROM {DbTables.Volunteers} v
                ";

                var result = conn.QueryAsync<Volunteer>(query);
                return result;
            });
        }

        public Task<Volunteer> GetVolunteerByID(int volunteerId)
        {
            return dbConnectionOwner.Use(async conn =>
            {
                var query = @$"
                    SELECT *
                    FROM {DbTables.Volunteers} v
                    WHERE v.""VolunteerID"" = @volunteerId;

                    SELECT *
                    FROM {DbTables.EmergencyContacts} ec
                    WHERE ec.""ContactID"" = @volunteerId;

                    SELECT *
                    FROM {DbTables.Centers} c
                    JOIN {DbTables.CenterPreferences} cp ON c.""CenterID"" = cp.""CenterID"" AND cp.""VolunteerID"" = @volunteerId;

                ";

                var multiResult = await conn.QueryMultipleAsync(query, new { volunteerId });
                var result = multiResult.Read<Volunteer>().FirstOrDefault();
                result.EmergencyContact = multiResult.Read<EmergencyContact>().First();
                result.CenterPreferences = multiResult.Read<Center>();
                return result;
            });
        }

        public Task<IEnumerable<Qualification>> GetVolunteerQualifcations(int volunteerId)
        {
            return dbConnectionOwner.Use(async conn =>
            {
                var query = @$"

                    SELECT*
                    FROM {DbTables.Qualifications} q
                    JOIN {DbTables.VolunteerQualifications} vq ON q.""QualificationID"" = vq.""QualificationID"" AND vq.""VolunteerID"" = @volunteerId

                ";

                var result = await conn.QueryAsync<Qualification>(query, new { volunteerId });

                return result;
            });
        }

        public Task<IEnumerable<AvailabilityTime>> GetAvailabilityTimes(int volunteerId)
        {
            return dbConnectionOwner.Use(async conn =>
            {
                var query = @$"
                    SELECT*
                    FROM {DbTables.AvailabilityTimes} avt
                    WHERE avt.""VolunteerID"" = @volunteerId;

                ";

                var result = await conn.QueryAsync<AvailabilityTime>(query, new { volunteerId });

                return result;
            });
        }
    }
}
