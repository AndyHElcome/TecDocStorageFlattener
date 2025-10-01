using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Concurrent;

namespace TecDocStorageFlattener.Services;


/// <summary>
/// Migrates a database the first time it is used (until the application is restarted). Should be registered as a singleton service.
/// </summary>
public class DatabaseMigrationService<T>
    where T : DbContext
{
    readonly ILogger logger;

    readonly ConcurrentDictionary<string, bool> dbContextMigrated = new(StringComparer.OrdinalIgnoreCase);

    public DatabaseMigrationService(ILogger logger)
    {
        this.logger = logger;
    }

    public void MigrateDatabase(T dbContext)
    {
        var connectionString = dbContext.Database.GetConnectionString();

        if (connectionString == null)
            return;

        if (!dbContextMigrated.ContainsKey(connectionString))
        {
            lock (dbContextMigrated)
            {
                if (!dbContextMigrated.ContainsKey(connectionString))
                {
                    logger.Information("Migrating database if required: {ConnectionString}", connectionString);

                    //dbContext.Database.EnsureDeleted();
                    //dbContext.Database.Migrate();
                    dbContext.Database.EnsureCreated();

                    dbContextMigrated[connectionString] = true;
                }
            }
        }
    }

    public void DropDatabase(T dbContext)
    {
        var connectionString = dbContext.Database.GetConnectionString();

        if (connectionString == null)
            return;

        if (!dbContextMigrated.ContainsKey(connectionString))
        {
            lock (dbContextMigrated)
            {
                if (!dbContextMigrated.ContainsKey(connectionString))
                {
                    logger.Information("Dropping database : {ConnectionString}", connectionString);

                    dbContext.Database.EnsureDeleted();

                    dbContextMigrated[connectionString] = true;
                }
            }
        }
    }
}
