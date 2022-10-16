using Blu.Net4.Data.Entities;
using SQLite.CodeFirst;
using System.Data.Entity;

namespace Blu.Net4.Data
{
    public class SqliteDbInitializer : SqliteCreateDatabaseIfNotExists<SqliteDbContext>
    {
        public SqliteDbInitializer(DbModelBuilder modelBuilder) : base(modelBuilder)
        {
        }

        protected override void Seed(SqliteDbContext context)
        {
            context.Settings.Add(new Setting());
            base.Seed(context);
        }
    }
}