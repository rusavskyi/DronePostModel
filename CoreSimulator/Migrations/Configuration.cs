using System;
using System.IO;


namespace CoreHost
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DronePostContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
        }

        protected override void Seed(DronePostContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
