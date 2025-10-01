using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TecDocStorageFlattener.Models.Contexts.TecdocReference22;
using TecDocStorageFlattener.Models.Contexts.Supplier;
using TecDocStorageFlattener.Services;

namespace TecDocStorageFlattener.Configuration;

public interface IConfiguration
{
}

public abstract class DBConfiguration<T> : IConfiguration
    where T : DbContext
{
    public required string ConnectionString { get; init; }
    public abstract T Context { get; }



    public DatabaseFactory<T> CreateDBFactory(ILogger? logger)
    {
        return new DatabaseFactory<T>(Context, logger);
    }

    public DbContextOptions<T> GetOptions()
    {
        return new DbContextOptionsBuilder<T>(new())
                //.UseApplicationServiceProvider(serviceProvider)
                //.UseLazyLoadingProxies()
                
                .UseSqlServer(ConnectionString,
                            sqlServerOptionsAction: sqlServerOptions => sqlServerOptions
                            .EnableRetryOnFailure()
                            .CommandTimeout(60)
                            .MaxBatchSize(500)).Options;
    }
}

public class SupplierDBConfiguration : DBConfiguration<SupplierDataContext>
{
    public override SupplierDataContext Context => new SupplierDataContext(GetOptions());
}

public class ReferenceDBConfiguration : DBConfiguration<TecdocReference22DbContext>
{
    public override TecdocReference22DbContext Context => new TecdocReference22DbContext(GetOptions());

}