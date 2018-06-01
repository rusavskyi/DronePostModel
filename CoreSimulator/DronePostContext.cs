using System.Data.Entity;
using DronePost.DataModel;


namespace CoreHost
{
    class DronePostContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerPackage> CustomerPackages { get; set; }
        public DbSet<Drone> Drones { get; set; }
        public DbSet<DroneModel> DroneModels{ get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<EmployeeWorkStation> EmployeeWorkStations { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PackageSize> PackageSizes { get; set; }
        public DbSet<PackageToStation> PackageToStation { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
    }
}
