using Microsoft.EntityFrameworkCore;
using Serilog;
using TafLoader.Models.Tecdoc;
using TecDocStorageFlattener.Helpers;
using TecDocStorageFlattener.Services;

namespace TecDocStorageFlattener.Configuration;

public interface ISupplierConfig
{

}

public class Supplier
{
    public string? BrandNo { get; set; }

    public List<ISupplierConfig>? SupplierConfigs { get; init; }
}

public class JsonConfig : ISupplierConfig
{
    public string ArticlesFilePath { get; set; }
    public string ArticlesFileName { get; set; } = "Articles.json";
    public string LinkagesFilePath { get; set; }
    public string LinkagesFileName { get; set; } = "Linkages.json";
}

public class ConnectionStringConfig
{
    public string ConnectionStringTemplate { get; init; } = "Server={server};Database={database};Integrated Security=False;User Id={user};Password={password};TrustServerCertificate=True";
    public string? Server { get; set; }
    public string? Database { get; set; }
    public string? BrandNo { get; set; }
    public string? ClientName { get; set; }
    public string? User { get; set; }
    public string? Password { get; set; }

    public string ConnectionString => GetConnectionString();

    public string GetConnectionString()
    {
        var connectionStringTemplate = ConnectionStringTemplate;
        TemplateHelpers.HandleTemplateParameter(ref connectionStringTemplate, "server", 0);
        TemplateHelpers.HandleTemplateParameter(ref connectionStringTemplate, "database", 1);
        TemplateHelpers.HandleTemplateParameter(ref connectionStringTemplate, "user", 2);
        TemplateHelpers.HandleTemplateParameter(ref connectionStringTemplate, "password", 3);
        TemplateHelpers.HandleTemplateParameter(ref connectionStringTemplate, "brandno", 3);
        TemplateHelpers.HandleTemplateParameter(ref connectionStringTemplate, "clientname", 3);

        return string.Format(connectionStringTemplate, Server, Database, User, Password, BrandNo, ClientName);
    }
}

public abstract class DBConfiguration<T> : ISupplierConfig //TODO Change to different config that isnt supplier
    where T : DbContext
{
    public ConnectionStringConfig ConnectionStringConfig { get; init; } = new() 
    { 
        ConnectionStringTemplate = "Server={server};Database=idp_{brandno};Integrated Security=False;User Id={user};Password={password};TrustServerCertificate=True", 
    };

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
                .UseSqlServer(ConnectionStringConfig.ConnectionString,
                            sqlServerOptionsAction: sqlServerOptions => sqlServerOptions
                            .EnableRetryOnFailure()
                            .CommandTimeout(60)
                            .MaxBatchSize(500)).Options;
    }
}

public class SupplierDBConfig : DBConfiguration<TecdocDbContext>
{
    public override TecdocDbContext Context => new TecdocDbContext(GetOptions());
}

public class ReferenceDBConfig : DBConfiguration<TecdocDbContext>
{
    public override TecdocDbContext Context => new TecdocDbContext(GetOptions());
}