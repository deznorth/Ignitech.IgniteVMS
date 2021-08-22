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

        #region READ

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

        public Task<Volunteer> GetVolunteerByID(int volunteerId)
        {
            return dbConnectionOwner.Use(async conn =>
            {
                var query = $@"
                    SELECT *
                    FROM {DbTables.Volunteers} v
                    WHERE v.""VolunteerID"" = @volunteerId;

                    SELECT *
                    FROM {DbTables.EmergencyContacts} ec
                    WHERE ec.""ContactID"" = (
                        SELECT v.""EmergencyContactID""
                        FROM {DbTables.Volunteers} v
                        WHERE v.""VolunteerID"" = @volunteerId
                    );

                    SELECT *
                    FROM {DbTables.Centers} c
                    JOIN {DbTables.CenterPreferences} cp ON c.""CenterID"" = cp.""CenterID"" AND cp.""VolunteerID"" = @volunteerId;
                ";

                var multiResult = await conn.QueryMultipleAsync(query, new { volunteerId });

                var result = multiResult.ReadFirstOrDefault<Volunteer>();

                result.EmergencyContact = multiResult.ReadFirstOrDefault<EmergencyContact>();

                result.CenterPreferences = multiResult.Read<Center>();

                return result;
            });
        }

        public Task<IEnumerable<Qualification>> GetVolunteerQualifications(int volunteerId)
        {
            return dbConnectionOwner.Use(conn =>
            {
                var query = @$"
                    SELECT *
                    FROM {DbTables.Qualifications} q
                    JOIN {DbTables.VolunteerQualifications} vq ON q.""QualificationID"" = vq.""QualificationID"" AND vq.""VolunteerID"" = @volunteerId
                ";

                var result = conn.QueryAsync<Qualification>(query, new { volunteerId });
                return result;
            });
        }

        public Task<IEnumerable<AvailabilityTime>> GetAvailabilityTimes(int volunteerId)
        {
            return dbConnectionOwner.Use(conn =>
            {
                var query = @$"
                    SELECT
                        avt.""AvailabilityTimeID"",
                        avt.""VolunteerID"",
                        avt.""StartTime""::varchar(25),
                        avt.""EndTime""::varchar(25)
                    FROM {DbTables.AvailabilityTimes} avt
                    WHERE avt.""VolunteerID"" = @volunteerId;
                ";

                var result = conn.QueryAsync<AvailabilityTime>(query, new { volunteerId });
                return result;
            });
        }

        #endregion

        #region CREATE

        public Task<Volunteer> CreateVolunteer(VolunteerCreateRequest request)
        {
            return dbConnectionOwner.UseTransaction(async (conn, transaction) =>
            {
                try
                {
                    // 1. Create User
                    var insertUser = $@"
                        INSERT INTO {DbTables.Users} (""Username"", ""Password"")
                        VALUES (@Username, @Password)
                        RETURNING *
                    ";

                    var user = await conn.QueryFirstAsync<UserResponse>(insertUser, request.User, transaction);

                    // 2. Create Emergency Contact
                    var insertEmergencyContact = $@"
                        INSERT INTO {DbTables.EmergencyContacts} (
                            ""Name"",
                            ""Email"",
                            ""Address"",
                            ""HomePhoneNumber"",
                            ""WorkPhoneNumber"",
                            ""CellPhoneNumber""
                        )
                        VALUES (
                            @Name,
                            @Email,
                            @Address,
                            @HomePhoneNumber,
                            @WorkPhoneNumber,
                            @CellPhoneNumber
                        )
                        RETURNING *
                    ";

                    var emergencyContact = await conn.QueryFirstAsync<EmergencyContact>(insertEmergencyContact, request.EmergencyContact, transaction);

                    // 3. Create Volunteer
                    var insertVolunteer = @$"
                        INSERT INTO {DbTables.Volunteers} (
                            ""UserID"",
	                        ""FirstName"",
	                        ""LastName"",
	                        ""Email"",
	                        ""HomePhoneNumber"",
	                        ""WorkPhoneNumber"",
	                        ""CellPhoneNumber"",
	                        ""Address"",
	                        ""EmergencyContactID"",
	                        ""DriversLicenseFiled"",
	                        ""SSNOnFile"",
                            ""Approved""
                        )
                        VALUES(
                            @UserID,
                            @FirstName,
                            @LastName,
                            @Email,
                            @HomePhoneNumber,
                            @WorkPhoneNumber,
                            @CellPhoneNumber,
                            @Address,
                            @contactId,
                            @DriversLicenseFiled,
                            @SSNOnFile,
                            @Approved
                        )
                        RETURNING *
                    ";

                    var volunteer = await conn.QueryFirstAsync<Volunteer>(insertVolunteer, new
                    {
                        user.UserID,
                        emergencyContact.ContactID,
                        request.FirstName,
                        request.LastName,
                        request.Email,
                        request.HomePhoneNumber,
                        request.WorkPhoneNumber,
                        request.CellPhoneNumber,
                        request.Address,
                        request.DriversLicenseFiled,
                        request.SSNOnFile,
                        request.Approved,
                    }, transaction);

                    // 4. Upsert Qualifications
                    var insertQualifications = $@"
                        INSERT INTO {DbTables.Qualifications} (""Type"", ""Label"")
                        VALUES(@Type::dbo.""QualificationType"", @Label)
                        ON CONFLICT DO NOTHING
                    ";

                    await conn.ExecuteAsync(insertQualifications, request.VolunteerQualifications, transaction);

                    // 5. Assign Qualifications
                    var insertVolunteerQualifications = $@"
                        INSERT INTO {DbTables.VolunteerQualifications} (""VolunteerID"", ""QualificationID"")
                        VALUES (
	                        @VolunteerID,
	                        (SELECT q.""QualificationID"" FROM {DbTables.Qualifications} q WHERE q.""Type""::varchar(50) = @Type AND q.""Label"" = @Label)
                        )
                        ON CONFLICT DO NOTHING;
                    ";

                    await conn.ExecuteAsync(insertVolunteerQualifications, request.VolunteerQualifications.Select(q => new { q.Label, q.Type, volunteer.VolunteerID }), transaction);

                    var selectQualifications = $@"
                        SELECT *
                        FROM {DbTables.Qualifications} q
                        WHERE CONCAT(q.""Type""::varchar(50), '_', q.""Label"") = ANY (@Selectors)
                    ";

                    var qualifications = await conn.QueryAsync<Qualification>(selectQualifications, new
                    {
                        Selectors = request.VolunteerQualifications.Select(q => string.Concat(q.Type, "_", q.Label)).ToArray(),
                    }, transaction);

                    // 6. Upsert Centers
                    var upsertCenters = $@"
                        INSERT INTO {DbTables.Centers} (""Name"")
                        VALUES(@Name)
                        ON CONFLICT DO NOTHING
                    ";

                    await conn.ExecuteAsync(upsertCenters, request.CenterPreferences, transaction);

                    // 7. Assign Center Preferences
                    var insertCenterPreferences = $@"
                        INSERT INTO {DbTables.CenterPreferences} (""VolunteerID"", ""CenterID"")
                        VALUES (
	                        @VolunteerID,
	                        (SELECT c.""CenterID"" FROM {DbTables.Centers} c WHERE c.""Name"" = @Name)
                        )
                        ON CONFLICT DO NOTHING
                    ";

                    await conn.ExecuteAsync(insertCenterPreferences, request.CenterPreferences.Select(c => new { c.Name, volunteer.VolunteerID }), transaction);

                    var selectCenters = $@"
                        SELECT *
                        FROM {DbTables.Centers} c
                        WHERE c.""Name"" = ANY (@Names)
                    ";

                    var centers = await conn.QueryAsync<Center>(selectCenters, new
                    {
                        Names = request.CenterPreferences.Select(q => q.Name).ToArray(),
                    }, transaction);

                    // 8. Create Availability Times
                    var insertAvailabilityTimes = $@"
                        INSERT INTO {DbTables.AvailabilityTimes} (""StartTime"", ""EndTime"", ""VolunteerID"")
                        VALUES(
                            TO_TIMESTAMP(@StartTime, 'HH24:MI:SS')::TIME,
                            TO_TIMESTAMP(@EndTime, 'HH24:MI:SS')::TIME,
                            @VolunteerID
                        )
                        ON CONFLICT DO NOTHING
                        RETURNING
                            ""AvailabilityTimeID"",
                            ""VolunteerID"",
                            ""StartTime""::varchar(50),
                            ""EndTime""::varchar(50)
                    ";

                    var tasks = request.AvailabilityTimes.Select(avt => conn.QueryFirstAsync<AvailabilityTime>(insertAvailabilityTimes, new
                    {
                        volunteer.VolunteerID,
                        avt.StartTime,
                        avt.EndTime,
                    }, transaction));

                    var availabilityTimes = (await Task.WhenAll(tasks)).AsEnumerable();

                    // 9. Put it all together
                    volunteer.User = user;
                    volunteer.EmergencyContact = emergencyContact;
                    volunteer.VolunteerQualifications = qualifications;
                    volunteer.CenterPreferences = centers;
                    volunteer.AvailabilityTimes = availabilityTimes;

                    transaction.Commit();
                    return volunteer;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            });
        }

        #endregion

        #region UPDATE

        #endregion

        #region DELETE

        public Task DeleteVolunteer(int volunteerId)
        {
            return dbConnectionOwner.UseTransaction(async (conn, transaction) =>
            {
                try
                {
                    /* Deleting the user will cascade delete the volunteer and that will cascade delete everything else
                     * except emergency contacts, so we have to remember to delete it so it's not left dangling
                    */
                    var selectVolunteer = $@"
                            SELECT v.""UserID"", v.""EmergencyContactID""
                            FROM {DbTables.Volunteers} v
                            WHERE v.""VolunteerID"" = @volunteerId
                        ";

                    var target = await conn.QueryFirstAsync<Volunteer>(selectVolunteer, new { volunteerId }, transaction);

                    var deleteUser = $@"
                            DELETE FROM {DbTables.Users}
                            WHERE ""UserID"" = @UserID
                        ";

                    await conn.ExecuteAsync(deleteUser, new { target.UserID }, transaction);

                    var deleteEmergencyContact = $@"
                            DELETE FROM {DbTables.EmergencyContacts}
                            WHERE ""ContactID"" = @EmergencyContactID
                        ";

                    await conn.ExecuteAsync(deleteEmergencyContact, new { target.EmergencyContactID }, transaction);

                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            });
        }

        #endregion
    }
}
