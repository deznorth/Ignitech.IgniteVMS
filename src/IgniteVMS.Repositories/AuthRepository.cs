using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Dapper;
using IgniteVMS.DataAccess.Constants;
using IgniteVMS.DataAccess.Contracts;
using IgniteVMS.Repositories.Contracts;
using IgniteVMS.Entities;
using System;

namespace IgniteVMS.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ILogger<AuthRepository> logger;
        private readonly IConnectionOwner dbConnectionOwner;

        public AuthRepository(
            ILogger<AuthRepository> logger,
            IConnectionOwner dbConnectionOwner
        )
        {
            this.logger = logger;
            this.dbConnectionOwner = dbConnectionOwner;
        }

        public async Task<User> AuthenticateUser(LoginRequest request)
        {
            return await dbConnectionOwner.Use(async conn =>
            {
                var query = @$"
                    SELECT *
                    FROM {DbTables.Users} u
                    WHERE u.""Username"" = @Username AND u.""Password"" = @Password
                ";

                var result = await conn.QueryFirstOrDefaultAsync<User>(query, request);
                return result;
            });
        }

        public async Task<UserResponse> SaveUser(User user)
        {
            try
            {
                return await dbConnectionOwner.Use(async conn =>
                {
                    var insertQuery = @$"
                        INSERT INTO {DbTables.Users} (""Username"", ""Password"", ""UserRole"")
                        VALUES (@Username, @Password, @UserRole::dbo.""UserRole"")
                    ";

                    var query = @$"SELECT * FROM {DbTables.Users} u WHERE u.""Username"" = @Username";

                    // Insert the new user into the database
                    var rowsAffected = await conn.ExecuteAsync(insertQuery, user);
                    // Select the newly created user
                    var createdUser = await conn.QueryFirstOrDefaultAsync<UserResponse>(query, user);

                    return createdUser;
                });
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }
    }
}
