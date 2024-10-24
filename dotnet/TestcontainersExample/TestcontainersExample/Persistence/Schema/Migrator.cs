using System.Data.Common;
using EvolveDb;
using EvolveDb.Configuration;
using Microsoft.Extensions.Logging;

namespace TestcontainersExample.Persistence.Schema;

public class Migrator
{
    private static readonly ILogger Logger = Logging.LoggerFactory().CreateLogger<Migrator>();
    private readonly DbDataSource _dataSource;

    public Migrator(DbDataSource dataSource)
    {
        this._dataSource = dataSource;
    }

    public void Migrate()
    {
        try
        {
            Logger.LogInformation("Migrating database...");
            using var connection = _dataSource.OpenConnection();
            var evolve = new Evolve(connection, msg => Logger.LogDebug(msg))
            {
                Locations = ["migrations"],
                IsEraseDisabled = true,
                Command = CommandOptions.Migrate
            };
            evolve.Migrate();
        }
        catch (Exception e)
        {
            Logger.LogCritical(e, "Failed to migrate database");
        }
    }
}