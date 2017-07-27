namespace RequestWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fml3 : DbMigration
    {
        public override void Up()
        {
            //AddColumn("dbo.Events", "Image", c => c.String());
        }
        
        public override void Down()
        {
           // DropColumn("dbo.Events", "Image");
        }
    }
}
