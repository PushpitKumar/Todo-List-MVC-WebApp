namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedListsTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TodoLists", "ListName", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TodoLists", "ListName", c => c.String(nullable: false, maxLength: 25));
        }
    }
}
