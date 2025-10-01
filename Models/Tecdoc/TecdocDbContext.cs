using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;

namespace TafLoader.Models.Tecdoc
{
    public partial class TecdocDbContext : DbContext
    {
        public TecdocDbContext(DbContextOptions options)
            : base(options)
        {
            this.Database.SetCommandTimeout(TimeSpan.FromDays(1));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Collation

            // Don't use SQL_* collations - they are for backwards compatibility only
            // see: https://docs.microsoft.com/en-us/sql/t-sql/statements/sql-server-collation-name-transact-sql?view=sql-server-ver15

            // Use the latest collation version available eg. _100_ (ie. use Latin1_General_100_CI_AS, not Latin1_General_CI_AS)
            // Otherwise some case mappings may be missing
            // see: https://docs.microsoft.com/en-us/sql/t-sql/statements/windows-collation-name-transact-sql?view=sql-server-ver15

            // Use _AS: C# is accent sensitive - even when ignoring case
            // string.Equals("è", "é", StringComparison.InvariantCultureIgnoreCase) == false

            // Case insensitive: makes sense for most columns eg. part number "ELC-001" is the same as "elc-001"

            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_100_CI_AS");

            #endregion

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                //var key = entityType.FindPrimaryKey();
                //if (key != null && key.Properties.Count > 1)
                //{
                //    // Workaround for "Entity type has composite primary key defined with data annotations. To set composite primary key, use fluent API."
                //    // (Why do they prevent this?)

                //    // Also, sort the primary keys by [Column(Order = ?)] (as in EF6)
                //    var properties = key.Properties.ToArray();
                //    var propertyKeys = properties.Select(c => (c.PropertyInfo.GetCustomAttribute<ColumnAttribute>()?.Order ?? int.MaxValue, c.Name)).ToArray();
                //    Array.Sort(propertyKeys, properties);

                //    entityType.SetPrimaryKey(properties);
                //}

                // Set "ON DELETE NO ACTION" for all foreign keys
                foreach (var fk in entityType.GetForeignKeys())
                    fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            SetupPrimaryKeys(modelBuilder);
        }
    }
}
