namespace pu_system_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Practices : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Practices",
                c => new
                {
                    PracticeId = c.Int(nullable: false, identity: true),
                    PracticeName = c.String(nullable: false, maxLength: 50),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(nullable: false),
                    InternshipId = c.Int(nullable: true),
                })
                .PrimaryKey(t => t.PracticeId)
                .ForeignKey("dbo.Internships", t => t.InternshipId, cascadeDelete: true)
                .Index(t => t.InternshipId);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Practices", "InternshipId", "dbo.Internships");
            DropIndex("dbo.Practices", new[] { "InternshipId" });
            DropTable("dbo.Practices");
        }
    }
}
