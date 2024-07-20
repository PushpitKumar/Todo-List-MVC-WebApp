namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(maxLength: 100),
                        ActivityId = c.Int(nullable: false),
                        commentTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        ActivityName = c.String(nullable: false, maxLength: 60),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskName = c.String(nullable: false, maxLength: 50),
                        CreationTime = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        DueTime = c.DateTime(nullable: false),
                        ListId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.TodoLists", t => t.ListId, cascadeDelete: true)
                .Index(t => t.ListId);
            
            CreateTable(
                "dbo.TaskPriorities",
                c => new
                    {
                        PriorityId = c.Int(nullable: false, identity: true),
                        PriorityType = c.String(maxLength: 20),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PriorityId)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.TaskStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusType = c.String(nullable: false, maxLength: 15),
                        TaskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.Tasks", t => t.TaskId, cascadeDelete: true)
                .Index(t => t.TaskId);
            
            CreateTable(
                "dbo.TodoLists",
                c => new
                    {
                        ListId = c.Int(nullable: false, identity: true),
                        ListName = c.String(nullable: false, maxLength: 25),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ListId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        MiddleName = c.String(maxLength: 30),
                        LastName = c.String(maxLength: 30),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 25),
                        PhoneNumber = c.String(maxLength: 10),
                        DateOfBirth = c.DateTime(nullable: false),
                        Country = c.String(maxLength: 20),
                        RegistrationDate = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        ProfileBio = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.Activities", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Tasks", "ListId", "dbo.TodoLists");
            DropForeignKey("dbo.TodoLists", "UserId", "dbo.Users");
            DropForeignKey("dbo.TaskStatus", "TaskId", "dbo.Tasks");
            DropForeignKey("dbo.TaskPriorities", "TaskId", "dbo.Tasks");
            DropIndex("dbo.TodoLists", new[] { "UserId" });
            DropIndex("dbo.TaskStatus", new[] { "TaskId" });
            DropIndex("dbo.TaskPriorities", new[] { "TaskId" });
            DropIndex("dbo.Tasks", new[] { "ListId" });
            DropIndex("dbo.Activities", new[] { "TaskId" });
            DropIndex("dbo.Comments", new[] { "ActivityId" });
            DropTable("dbo.Users");
            DropTable("dbo.TodoLists");
            DropTable("dbo.TaskStatus");
            DropTable("dbo.TaskPriorities");
            DropTable("dbo.Tasks");
            DropTable("dbo.Activities");
            DropTable("dbo.Comments");
        }
    }
}
