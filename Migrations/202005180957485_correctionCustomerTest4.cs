namespace VidlyMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctionCustomerTest4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String());
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "MembershipTypeId", c => c.Byte());
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id");
        }
    }
}
