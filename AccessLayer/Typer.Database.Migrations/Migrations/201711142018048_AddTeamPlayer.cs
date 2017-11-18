namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamPlayer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbPlayers",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.Int(nullable: false),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Teams", t => t.TeamId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbPlayers", "TeamId", "dbo.Teams");
            DropIndex("dbo.DbPlayers", new[] { "TeamId" });
            DropTable("dbo.DbPlayers");
        }
    }
}
