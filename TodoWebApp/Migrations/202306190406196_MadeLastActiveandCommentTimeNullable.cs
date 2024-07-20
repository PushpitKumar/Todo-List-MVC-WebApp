namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeLastActiveandCommentTimeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "commentTime", c => c.DateTime());
            AlterColumn("dbo.Users", "LastActive", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "LastActive", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Comments", "commentTime", c => c.DateTime(nullable: false));
        }
    }
}
