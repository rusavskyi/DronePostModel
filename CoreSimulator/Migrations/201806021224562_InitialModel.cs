namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CustomerPackages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(nullable: false),
                        Sender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Sender_Id, cascadeDelete: true)
                .Index(t => t.Package_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipientPhoneNumber = c.String(nullable: false, maxLength: 50),
                        Weight = c.Single(nullable: false),
                        DestinationStation_Id = c.Int(nullable: false),
                        Size_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.DestinationStation_Id, cascadeDelete: true)
                .ForeignKey("dbo.PackageSizes", t => t.Size_Id, cascadeDelete: true)
                .Index(t => t.DestinationStation_Id)
                .Index(t => t.Size_Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        Longitude = c.Single(nullable: false),
                        Latitude = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PackageSizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SizeName = c.String(nullable: false, maxLength: 255),
                        Width = c.Single(nullable: false),
                        Height = c.Single(nullable: false),
                        Length = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyAgent = c.Boolean(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        City_Id = c.Int(nullable: false),
                        Company_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.Companies", t => t.Company_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Company_Id);
            
            CreateTable(
                "dbo.DroneModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelName = c.String(nullable: false, maxLength: 255),
                        MaxWeightCarry = c.Single(nullable: false),
                        MaxFlightDistance = c.Single(nullable: false),
                        BatteryCapacity = c.Single(nullable: false),
                        MaxSizeCarry_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PackageSizes", t => t.MaxSizeCarry_Id, cascadeDelete: true)
                .Index(t => t.MaxSizeCarry_Id);
            
            CreateTable(
                "dbo.Drones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Longitude = c.Single(nullable: false),
                        Latitude = c.Single(nullable: false),
                        Model_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DroneModels", t => t.Model_Id, cascadeDelete: true)
                .Index(t => t.Model_Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        BirthDate = c.DateTime(nullable: false),
                        Address = c.String(nullable: false, maxLength: 255),
                        Address2 = c.String(maxLength: 255),
                        City_Id = c.Int(nullable: false),
                        WorkPost_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.City_Id, cascadeDelete: true)
                .ForeignKey("dbo.EmployeeTypes", t => t.WorkPost_Id, cascadeDelete: true)
                .Index(t => t.City_Id)
                .Index(t => t.WorkPost_Id);
            
            CreateTable(
                "dbo.EmployeeTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeWorkStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Id = c.Int(nullable: false),
                        Station_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.Employee_Id, cascadeDelete: true)
                .ForeignKey("dbo.Stations", t => t.Station_Id, cascadeDelete: true)
                .Index(t => t.Employee_Id)
                .Index(t => t.Station_Id);
            
            CreateTable(
                "dbo.PackageToStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Package_Id = c.Int(),
                        Station_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .ForeignKey("dbo.Stations", t => t.Station_Id)
                .Index(t => t.Package_Id)
                .Index(t => t.Station_Id);
            
            CreateTable(
                "dbo.Transfers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArrivalTime = c.DateTime(),
                        DepartureTime = c.DateTime(),
                        ArrivalStation_Id = c.Int(),
                        DepartureStation_Id = c.Int(),
                        Drone_Id = c.Int(),
                        Package_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stations", t => t.ArrivalStation_Id)
                .ForeignKey("dbo.Stations", t => t.DepartureStation_Id)
                .ForeignKey("dbo.Drones", t => t.Drone_Id)
                .ForeignKey("dbo.Packages", t => t.Package_Id)
                .Index(t => t.ArrivalStation_Id)
                .Index(t => t.DepartureStation_Id)
                .Index(t => t.Drone_Id)
                .Index(t => t.Package_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transfers", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Transfers", "Drone_Id", "dbo.Drones");
            DropForeignKey("dbo.Transfers", "DepartureStation_Id", "dbo.Stations");
            DropForeignKey("dbo.Transfers", "ArrivalStation_Id", "dbo.Stations");
            DropForeignKey("dbo.PackageToStations", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.PackageToStations", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.EmployeeWorkStations", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.EmployeeWorkStations", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Employees", "WorkPost_Id", "dbo.EmployeeTypes");
            DropForeignKey("dbo.Employees", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Drones", "Model_Id", "dbo.DroneModels");
            DropForeignKey("dbo.DroneModels", "MaxSizeCarry_Id", "dbo.PackageSizes");
            DropForeignKey("dbo.CustomerPackages", "Sender_Id", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Company_Id", "dbo.Companies");
            DropForeignKey("dbo.Customers", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.CustomerPackages", "Package_Id", "dbo.Packages");
            DropForeignKey("dbo.Packages", "Size_Id", "dbo.PackageSizes");
            DropForeignKey("dbo.Packages", "DestinationStation_Id", "dbo.Stations");
            DropIndex("dbo.Transfers", new[] { "Package_Id" });
            DropIndex("dbo.Transfers", new[] { "Drone_Id" });
            DropIndex("dbo.Transfers", new[] { "DepartureStation_Id" });
            DropIndex("dbo.Transfers", new[] { "ArrivalStation_Id" });
            DropIndex("dbo.PackageToStations", new[] { "Station_Id" });
            DropIndex("dbo.PackageToStations", new[] { "Package_Id" });
            DropIndex("dbo.EmployeeWorkStations", new[] { "Station_Id" });
            DropIndex("dbo.EmployeeWorkStations", new[] { "Employee_Id" });
            DropIndex("dbo.Employees", new[] { "WorkPost_Id" });
            DropIndex("dbo.Employees", new[] { "City_Id" });
            DropIndex("dbo.Drones", new[] { "Model_Id" });
            DropIndex("dbo.DroneModels", new[] { "MaxSizeCarry_Id" });
            DropIndex("dbo.Customers", new[] { "Company_Id" });
            DropIndex("dbo.Customers", new[] { "City_Id" });
            DropIndex("dbo.Packages", new[] { "Size_Id" });
            DropIndex("dbo.Packages", new[] { "DestinationStation_Id" });
            DropIndex("dbo.CustomerPackages", new[] { "Sender_Id" });
            DropIndex("dbo.CustomerPackages", new[] { "Package_Id" });
            DropTable("dbo.Transfers");
            DropTable("dbo.PackageToStations");
            DropTable("dbo.EmployeeWorkStations");
            DropTable("dbo.EmployeeTypes");
            DropTable("dbo.Employees");
            DropTable("dbo.Drones");
            DropTable("dbo.DroneModels");
            DropTable("dbo.Customers");
            DropTable("dbo.PackageSizes");
            DropTable("dbo.Stations");
            DropTable("dbo.Packages");
            DropTable("dbo.CustomerPackages");
            DropTable("dbo.Companies");
            DropTable("dbo.Cities");
        }
    }
}
