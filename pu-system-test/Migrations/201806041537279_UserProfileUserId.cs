namespace pu_system_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserProfileUserId : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserProfile",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    ProfileCreated = c.Boolean(nullable: false),
                    ApplicationUser = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ApplicationUser);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserProfile", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UserProfile", new[] { "ApplicationUser" });
            DropIndex("dbo.UserProfile", new[] { "UserId" });
            DropTable("dbo.UserProfile");
        }
    }
}
