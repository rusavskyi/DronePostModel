namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateCustomer : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO Customers (CompanyAgent, FirstName, LastName, BirthDate, Address, Address2, City_Id, Company_Id)
                VALUES (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 1, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 1, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 1, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 1, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 2, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 2, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 2, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 2, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 3, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 3, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 4, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 4, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 1, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 5, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 2, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 1, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 3, NULL),
                       (0, 'GenericSurname', 'GenericName', '1/01/1975', 'Generic Address', '', 4, NULL)");
        }
        
        public override void Down()
        {
        }
    }
}
