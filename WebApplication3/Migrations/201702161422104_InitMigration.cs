namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Priority",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Int(nullable: false),
                        Title = c.String(),
                        Description = c.String(),
                        PriorityID = c.Int(nullable: false),
                        StatusID = c.Int(nullable: false),
                        AssignedToID = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        DueDate = c.DateTime(nullable: false),
                        CompleteDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.AssignedToID)
                .ForeignKey("dbo.Users", t => t.OwnerID)
                .ForeignKey("dbo.Priority", t => t.PriorityID, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusID, cascadeDelete: true)
                .Index(t => t.OwnerID)
                .Index(t => t.PriorityID)
                .Index(t => t.StatusID)
                .Index(t => t.AssignedToID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        fName = c.String(),
                        lName = c.String(),
                        email = c.String(),
                        pNumber = c.String(),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tasks", "StatusID", "dbo.Status");
            DropForeignKey("dbo.Tasks", "PriorityID", "dbo.Priority");
            DropForeignKey("dbo.Tasks", "OwnerID", "dbo.Users");
            DropForeignKey("dbo.Tasks", "AssignedToID", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "AssignedToID" });
            DropIndex("dbo.Tasks", new[] { "StatusID" });
            DropIndex("dbo.Tasks", new[] { "PriorityID" });
            DropIndex("dbo.Tasks", new[] { "OwnerID" });
            DropTable("dbo.Users");
            DropTable("dbo.Tasks");
            DropTable("dbo.Status");
            DropTable("dbo.Priority");
        }
    }
}
