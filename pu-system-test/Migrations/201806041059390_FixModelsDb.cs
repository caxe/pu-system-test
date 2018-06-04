namespace pu_system_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixModelsDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Practices", "InternshipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Practices", "InternshipId");
            AddForeignKey("dbo.Practices", "InternshipId", "dbo.Internships", "InternshipId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Practices", "InternshipId", "dbo.Internships");
            DropIndex("dbo.Practices", new[] { "InternshipId" });
            DropColumn("dbo.Practices", "InternshipId");
        }
    }
}
