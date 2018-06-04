namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateStations : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Stations (Name, Address, Longitude, Latitude)
                VALUES ('Station 1', '3:3', 300, 300),
                       ('Station 2', '3:9', 300, 900),
                       ('Station 3', '3:15', 300, 1500),
                       ('Station 4', '3:21', 300, 2100),
                       ('Station 5', '3:28', 300, 2800),
                       ('Station 6', '9:6', 900, 600),
                       ('Station 7', '9:13', 900, 1300),
                       ('Station 8', '9:18.5', 900, 1850),
                       ('Station 9', '9:25', 900, 2500),
                       ('Station 10', '15:9', 1500, 900),
                       ('Station 11', '15:16', 1500, 1600),
                       ('Station 12', '15:22', 1500, 2200),
                       ('Station 13', '20:12', 2000, 1200),
                       ('Station 14', '20:19', 2000, 1900),
                       ('Station 15', '25:16', 2500, 1600),
                       ('Station 16', '20:2', 2000, 200),
                       ('Station 17', '20:30', 2000, 3000),
                       ('Station 18', '24:7', 2400, 700),
                       ('Station 19', '24:25', 2400, 2500),
                       ('Station 20', '13:32', 1300, 3200),
                       ('Station 21', '12:0', 1200, 0),
                       ('Station 22', '6:34', 600, 3400)");
        }
        
        public override void Down()
        {
        }
    }
}
