namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUsersTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
            AddColumn("dbo.Users", "ConfirmPassword", c => c.String(nullable: false, maxLength: 25));
            AddColumn("dbo.Users", "LastActive", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "MiddleName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(maxLength: 13));
            AlterColumn("dbo.Users", "Gender", c => c.String(maxLength: 1, unicode: false));
            AlterColumn("dbo.Users", "Country", c => c.String(maxLength: 20, unicode: false));
            AlterColumn("dbo.Users", "ProfileBio", c => c.String(maxLength: 300));
            DropColumn("dbo.Users", "LastLogin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "LastLogin", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "ProfileBio", c => c.String(maxLength: 50));
            AlterColumn("dbo.Users", "Country", c => c.String(maxLength: 20));
            AlterColumn("dbo.Users", "Gender", c => c.String(maxLength: 1));
            AlterColumn("dbo.Users", "PhoneNumber", c => c.String(maxLength: 10));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "MiddleName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.Users", "LastActive");
            DropColumn("dbo.Users", "ConfirmPassword");
            DropColumn("dbo.Users", "IsAdmin");
            DropColumn("dbo.Users", "UserName");
        }
    }
}
