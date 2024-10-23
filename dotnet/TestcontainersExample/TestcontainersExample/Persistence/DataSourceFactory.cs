using Npgsql;

namespace TestcontainersExample.Persistence;

public class DataSourceFactory(string connectionString)
{
    public NpgsqlDataSource Create() => new NpgsqlDataSourceBuilder(connectionString).Build();
    
}