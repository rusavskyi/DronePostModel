namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateModels : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO DroneModels (ModelName, MaxSizeCarry_Id, MaxWeightCarry, MaxFlightDistance, BatteryCapacity)
                VALUES ('ACarrier', 1, 100, 1000, 2000),
                       ('BCarrier', 2, 200, 1000, 2000),
                       ('CCarrier', 3, 300, 2000, 4000),
                       ('DCarrier', 4, 400, 10000, 20000),
                       ('ECarrier', 5, 500, 10000, 20000),
                       ('FCarrier', 6, 600, 10000, 20000),
                       ('GCarrier', 7, 300, 10000, 20000)");
        }
        
        public override void Down()
        {
        }
    }
}
