namespace RequestWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fml1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Title", c => c.String());
            AddColumn("dbo.Events", "Details", c => c.String());
            AddColumn("dbo.Events", "Location", c => c.String());
            AddColumn("dbo.Events", "DateAndTime", c => c.String());
        }

        public override void Down()
        {
            DropColumn("dbo.Events", "DateAndTime");
            DropColumn("dbo.Events", "Location");
            DropColumn("dbo.Events", "Details");
            DropColumn("dbo.Events", "Title");
        }
    }
}
