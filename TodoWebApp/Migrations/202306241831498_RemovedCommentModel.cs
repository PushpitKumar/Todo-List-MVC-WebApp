namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedCommentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Comments", new[] { "ActivityId" });
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(maxLength: 300),
                        ActivityId = c.Int(nullable: false),
                        commentTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateIndex("dbo.Comments", "ActivityId");
            AddForeignKey("dbo.Comments", "ActivityId", "dbo.Activities", "ActivityId", cascadeDelete: true);
        }
    }
}
