namespace VidlyMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMovieClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Customers", "Dob", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Dob");
            DropTable("dbo.Movies");
        }
    }
}
