using System.Data.Common;
using EvolveDb;
using NLog;

namespace TestcontainersExample.Persistence.Schema;

public class Migrator
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    private readonly DbDataSource _dataSource;
    public Migrator(DbDataSource dataSource)
    {
        this._dataSource = dataSource;
    }

    public void Migrate()
    {
        try
        {
            Logger.Info("Migrating database...");
            using var connection = _dataSource.OpenConnection();
            var evolve = new Evolve(connection, msg => Logger.Debug(msg))     {
                Locations = ["migrations"],
                IsEraseDisabled = true
            };
            evolve.Migrate();
        }
        catch (Exception e)
        {
            Logger.Fatal(e, "Failed to migrate database");
        }
    }
}