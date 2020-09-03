namespace VidlyMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CorrectingCustomerClassDOB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Dob", c => c.Int());
        }
    }
}
