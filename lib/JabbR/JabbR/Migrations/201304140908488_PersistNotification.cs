namespace JabbR.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PersistNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatMessages", "ImageUrl", c => c.String());
            AddColumn("dbo.ChatMessages", "Source", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatMessages", "Source");
            DropColumn("dbo.ChatMessages", "ImageUrl");
        }
    }
}
