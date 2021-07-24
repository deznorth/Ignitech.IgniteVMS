using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IgniteVMS.DataAccess.Contracts;
using Npgsql;

namespace IgniteVMS.DataAccess.Modules
{
    public class ConnectionOwner : IConnectionOwner
    {
        private readonly string connectionString;

        public ConnectionOwner(ConnectionStringResolver connectionStringResolver) =>
            this.connectionString = connectionStringResolver.getConnectionString;
            

        public async Task<TResult> Use<TResult>(Func<NpgsqlConnection, Task<TResult>> func)
        {
            using (var cnxn = new NpgsqlConnection(connectionString))
            {
                await cnxn.OpenAsync().ConfigureAwait(false);
                return await func(cnxn).ConfigureAwait(false);
            }
        }

        public async Task Use(Func<NpgsqlConnection, Task> func)
        {
            using (var cnxn = new NpgsqlConnection(connectionString))
            {
                await cnxn.OpenAsync().ConfigureAwait(false);
                await func(cnxn).ConfigureAwait(false);
            }
        }

        public TResult UseSync<TResult>(Func<NpgsqlConnection, TResult> func)
        {
            using (var cnxn = new NpgsqlConnection(connectionString))
            {
                cnxn.Open();
                return func(cnxn);
            }
        }

        public async IAsyncEnumerable<TResult> Use<TResult>(Func<NpgsqlConnection, IAsyncEnumerable<TResult>> func)
        {
            using var conn = new NpgsqlConnection(connectionString);
            await conn.OpenAsync();
            await foreach (var result in func(conn))
            {
                yield return result;
            }
        }
    }
}
