namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateModels : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO DroneModels (ModelName, MaxWeightCarry, MaxFlightDistance, BatteryCapacity, MaxSizeCarry_Id)
                VALUES ('ACarrier', 100, 1000, 2000, 1),
                       ('BCarrier', 200, 1000, 2000, 2),
                       ('CCarrier', 300, 2000, 4000, 3),
                       ('DCarrier', 400, 10000, 20000, 4),
                       ('ECarrier', 500, 10000, 20000, 5),
                       ('FCarrier', 600, 10000, 20000, 6),
                       ('GCarrier', 300, 10000, 20000, 7)");
        }
        
        public override void Down()
        {
        }
    }
}
