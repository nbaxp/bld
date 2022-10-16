using Blu.Net4.Data.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Blu.Net4.Data
{
    public class SqliteDbContext : DbContext
    {
        public SqliteDbContext() : base("sqlite")
        {
            this.Database.Log = o => System.Diagnostics.Debug.WriteLine(o);
        }

        public DbSet<Setting> Settings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Properties<Guid>().Where(x => x.Name == "Id").Configure(x => x.IsKey().HasColumnOrder(1));
            var sqliteConnectionInitializer = new SqliteDbInitializer(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);
        }
    }
}