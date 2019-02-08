namespace poll_application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PollOptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PollId = c.Int(nullable: false),
                        Votes = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
            CreateTable(
                "dbo.Polls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(),
                        Votes = c.Int(nullable: false),
                        MultiVote = c.Boolean(nullable: false),
                        Private = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IpAdress = c.String(),
                        PollId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Polls", t => t.PollId, cascadeDelete: true)
                .Index(t => t.PollId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "PollId", "dbo.Polls");
            DropForeignKey("dbo.PollOptions", "PollId", "dbo.Polls");
            DropIndex("dbo.Votes", new[] { "PollId" });
            DropIndex("dbo.PollOptions", new[] { "PollId" });
            DropTable("dbo.Votes");
            DropTable("dbo.Polls");
            DropTable("dbo.PollOptions");
        }
    }
}
