namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedTasksTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TaskPriorities", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskStatus", "TaskId", "dbo.Tasks");
            DropIndex("dbo.TaskPriorities", new[] { "TaskId" });
            DropIndex("dbo.TaskStatus", new[] { "TaskId" });
            AddColumn("dbo.Tasks", "TimeOfCreation", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tasks", "Priority", c => c.String(nullable: false, maxLength: 6, unicode: false));
            AddColumn("dbo.Tasks", "Status", c => c.String(nullable: false, maxLength: 15, unicode: false));
            DropColumn("dbo.Tasks", "CreationTime");
            DropTable("dbo.TaskPriorities");
            DropTable("dbo.TaskStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusType = c.String(nullable: false, maxLength: 15),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId);
            
            CreateTable(
                "dbo.TaskPriorities",
                c => new
                    {
                        PriorityId = c.Int(nullable: false, identity: true),
                        PriorityType = c.String(maxLength: 20),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriorityId);
            
            AddColumn("dbo.Tasks", "CreationTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Tasks", "Status");
            DropColumn("dbo.Tasks", "Priority");
            DropColumn("dbo.Tasks", "TimeOfCreation");
            CreateIndex("dbo.TaskStatus", "TaskId");
            CreateIndex("dbo.TaskPriorities", "TaskId");
            AddForeignKey("dbo.TaskStatus", "TaskId", "dbo.Tasks", "TaskId", cascadeDelete: true);
            AddForeignKey("dbo.TaskPriorities", "TaskId", "dbo.Tasks", "TaskId", cascadeDelete: true);
        }
    }
}
