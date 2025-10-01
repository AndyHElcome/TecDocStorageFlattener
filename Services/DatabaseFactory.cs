using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using TecDocStorageFlattener.Models.Contexts.Supplier;

namespace TecDocStorageFlattener.Services;

public class DatabaseFactory<T> : IDisposable
    where T : DbContext
{
    readonly T context;
    //readonly IServiceProvider serviceProvider;
    readonly ILogger logger;
    readonly DatabaseMigrationService<T> databaseMigrationServiceDataContext;
    readonly ConcurrentDictionary<string, T> cacheDataContext = new(StringComparer.OrdinalIgnoreCase);

    public DatabaseFactory(
        T context,
        //IServiceProvider serviceProvider,
        ILogger logger
        //DatabaseMigrationService<T> databaseMigrationServiceTRCDataContext
        )
    {
        //this.serviceProvider = serviceProvider;
        this.context = context;
        this.logger = logger;
        databaseMigrationServiceDataContext = new(logger);
    }

    public void Dispose()
    {
        foreach (var dbContext in cacheDataContext.Values)
        {
            try
            {
                dbContext.Dispose();
            }
            catch (Exception ex)
            {
                // Log error and continue
                logger.Error(ex, $"DatabaseFactory: Failed to dispose DbContext: {typeof(T).Name}");
            }
        }
    }

    /// <summary>
    /// gets the DbContext (use carefully, check database exists)
    /// </summary>
    public T ConnectToDataContext()
    {
        T db = context;

        return db;
    }


    /// <summary>
    /// Get (and migrate db) the shared DbContext that will be disposed when <see cref="DatabaseFactory"/> is disposed (which should be registered as a scoped service).
    /// </summary>
    public T GetDataContext(string client)
    {
        // just retrun it - no issue as mentioned below
        //return CreateTRCDataContext(client);
        
        // this gets the cached version if any - think was causing issue when application (iis) is set to always run
        return cacheDataContext.GetOrAdd(client, CreateDataContext());
    }

    /// <summary>
    /// Create a new DbContext, which the caller must manually dispose.
    /// </summary>
    public T CreateDataContext()
    {
        T db = context;

        // create database if it does not exists
        databaseMigrationServiceDataContext.MigrateDatabase(db);

        return db;
    }

    
}
