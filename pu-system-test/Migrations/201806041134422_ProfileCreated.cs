namespace pu_system_test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileCreated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ProfileCreated", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ProfileCreated");
        }
    }
}
