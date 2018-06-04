namespace CoreHost
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateSizes : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO PackageSizes (SizeName, Width, Height, Length)
                    VALUES ('A',10,10,10),
                            ('B',20,20,20),
                            ('C',50,50,50),
                            ('D',100,100,100),
                            ('E',250,250,250),
                            ('F',500,500,500),
                            ('G',50,50,100)");
        }
        
        public override void Down()
        {
        }
    }
}
