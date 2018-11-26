namespace SistemaDeCheques.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaDeCheques.Models.SistemaDeChequesContext>
    {
        public Configuration()
        {
<<<<<<< HEAD
            AutomaticMigrationsEnabled = false;

            // register mysql code generator
            SetSqlGenerator("MySql.Data.MySqlClient", new MyMigrationSQLGenerator());
=======
            AutomaticMigrationsEnabled = true;
            SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator());
>>>>>>> 199893789369d9264db337e0b2802e6fab36c1ce
        }

        protected override void Seed(SistemaDeCheques.Models.SistemaDeChequesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }   
    }
}
