namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCities : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Cities (Name)
                VALUES ('Wroclaw'), ('Warshaw'), ('Krakow'), ('Poznan'), ('Gdansk')");
        }
        
        public override void Down()
        {
        }
    }
}
