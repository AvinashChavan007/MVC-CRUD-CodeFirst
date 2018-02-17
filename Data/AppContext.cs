
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using Core;

namespace Data
{
    public class AppContext : DbContext
    {
        #region Constructor
        public AppContext(string connectionString) : base(connectionString)
        {
            ((IObjectContextAdapter)this).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        }

        public AppContext()
        {

        }
        #endregion

        private void ConfigureModel(DbModelBuilder modelBuilder)
        {
            // Automate the process to add the configuration
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !string.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Override default conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            ConfigureModel(modelBuilder);

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AppContext, Migrations.Configuration>());

            base.OnModelCreating(modelBuilder);
        }

        public IDictionary<string, object> GetModifiedProperties(BaseEntity entity)
        {
            var entry = Entry(entity);
            var modifiedPropertyNames = from p in entry.CurrentValues.PropertyNames
                                        where entry.Property(p).IsModified
                                        select p;

            return modifiedPropertyNames.ToDictionary(name => name, name => entry.Property(name).OriginalValue);
        }

    }
}
