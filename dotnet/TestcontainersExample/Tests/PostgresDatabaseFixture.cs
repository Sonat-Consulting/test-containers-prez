using Npgsql;
using Testcontainers.PostgreSql;
using TestcontainersExample.Persistence;
using TestcontainersExample.Persistence.Schema;

namespace Tests;

public class PostgresDatabaseFixture : IAsyncLifetime
{
    private readonly PostgreSqlContainer _container =
        new PostgreSqlBuilder()
            .WithImage("postgres:12.20-alpine")
            .Build();

    public NpgsqlDataSource DataSource => new DataSourceFactory(_container.GetConnectionString()).Create();

    public Task InitializeAsync()
    {
        return _container.StartAsync().ContinueWith(t => RunMigrations());
    }

    private Task RunMigrations()
    {
        new Migrator(DataSource).Migrate();
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
        => _container.DisposeAsync().AsTask();
}