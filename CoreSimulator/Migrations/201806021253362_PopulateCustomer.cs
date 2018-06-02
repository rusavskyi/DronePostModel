namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Customers (CompanyAgent, FirstName, LastName, BirthDate, Address, Address2, City_Id, Company_Id)
                VALUES (),
               ");
        }
        
        public override void Down()
        {
        }
    }
}
