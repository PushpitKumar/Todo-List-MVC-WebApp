namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TodoDb1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Gender", c => c.String(maxLength: 1));
        }
      
        public override void Down()
        {
            DropColumn("dbo.Users", "Gender");
        }
    }
}
