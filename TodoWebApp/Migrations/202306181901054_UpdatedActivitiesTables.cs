namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedActivitiesTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "isCompleted", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Activities", "ActivityName", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Activities", "ActivityName", c => c.String(nullable: false, maxLength: 60));
            DropColumn("dbo.Activities", "isCompleted");
        }
    }
}
