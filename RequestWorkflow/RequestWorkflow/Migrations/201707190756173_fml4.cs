namespace RequestWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fml4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Date = c.DateTime(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.EventId);
            
            AddColumn("dbo.Events", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "ApplicationUserId");
            AddForeignKey("dbo.Events", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropForeignKey("dbo.Events", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "ApplicationUserId" });
            DropIndex("dbo.Comments", new[] { "EventId" });
            DropColumn("dbo.Events", "ApplicationUserId");
            DropTable("dbo.Comments");
        }
    }
}
