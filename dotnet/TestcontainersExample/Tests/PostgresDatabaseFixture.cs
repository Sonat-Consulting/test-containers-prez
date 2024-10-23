using NLog;
using Npgsql;
using Testcontainers.PostgreSql;
using TestcontainersExample.Persistence;
using TestcontainersExample.Persistence.Schema;

namespace Tests;

public class PostgresDatabaseFixture: IAsyncLifetime
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    private readonly PostgreSqlContainer _container = 
        new PostgreSqlBuilder()
            .WithImage("postgres:12.20-alpine")
            .Build();
    public NpgsqlDataSource DataSource => new DataSourceFactory(_container.GetConnectionString()).Create();

    public Task InitializeAsync()
    {
        Logger.Debug("Starting PostgreSql Database");
        return _container.StartAsync();
    }
    public Task DisposeAsync() 
        => _container.DisposeAsync().AsTask();
}