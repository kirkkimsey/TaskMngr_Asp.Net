namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "uName", c => c.String());
            AddColumn("dbo.Users", "pWord", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "pWord");
            DropColumn("dbo.Users", "uName");
        }
    }
}
