namespace pu_system_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModelsDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Firms",
                c => new
                    {
                        FirmId = c.Int(nullable: false, identity: true),
                        FirmName = c.String(nullable: false, maxLength: 100),
                        Address = c.String(maxLength: 100),
                        Description = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.FirmId);
            
            CreateTable(
                "dbo.Internships",
                c => new
                    {
                        InternshipId = c.Int(nullable: false, identity: true),
                        FirmId = c.Int(nullable: false),
                        Spots = c.Int(nullable: false),
                        Technologies = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.InternshipId)
                .ForeignKey("dbo.Firms", t => t.FirmId, cascadeDelete: true)
                .Index(t => t.FirmId);
            
            CreateTable(
                "dbo.Practices",
                c => new
                    {
                        PracticeId = c.Int(nullable: false, identity: true),
                        PracticeName = c.String(nullable: false, maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PracticeId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentFN = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        AssignedTo = c.Int(nullable: false),
                        Firm_FirmId = c.Int(),
                    })
                .PrimaryKey(t => t.StudentFN)
                .ForeignKey("dbo.Firms", t => t.Firm_FirmId)
                .Index(t => t.Firm_FirmId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Firm_FirmId", "dbo.Firms");
            DropForeignKey("dbo.Internships", "FirmId", "dbo.Firms");
            DropIndex("dbo.Students", new[] { "Firm_FirmId" });
            DropIndex("dbo.Internships", new[] { "FirmId" });
            DropTable("dbo.Students");
            DropTable("dbo.Practices");
            DropTable("dbo.Internships");
            DropTable("dbo.Firms");
        }
    }
}
