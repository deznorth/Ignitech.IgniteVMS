using Npgsql;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IgniteVMS.DataAccess.Contracts
{
    public interface IConnectionOwner
    {
        // Create and open a connection, then execute the specified function within the scope of that connection.
        Task<TResult> Use<TResult>(Func<NpgsqlConnection, Task<TResult>> func);

        Task Use(Func<NpgsqlConnection, Task> func);

        TResult UseSync<TResult>(Func<NpgsqlConnection, TResult> func);

        IAsyncEnumerable<TResult> Use<TResult>(Func<NpgsqlConnection, IAsyncEnumerable<TResult>> func);
    }
}
