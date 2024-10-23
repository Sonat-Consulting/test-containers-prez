using System.Data.Common;
using Npgsql;

namespace TestcontainersExample.Persistence;

public class ConnectionFactory(NpgsqlDataSource dataSource)
{
    private readonly NpgsqlDataSource _dataSource = dataSource ?? throw new ArgumentNullException(nameof(dataSource));

    public async Task<NpgsqlConnection> CreateAsync() => await _dataSource.OpenConnectionAsync();
    
    public NpgsqlConnection Create() => _dataSource.OpenConnection();
}