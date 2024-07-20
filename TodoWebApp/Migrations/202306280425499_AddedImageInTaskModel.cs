namespace TodoWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageInTaskModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tasks", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tasks", "ImagePath");
        }
    }
}
