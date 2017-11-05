namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDbMatchScore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbMatchScores",
                c => new
                    {
                        MatchScoreId = c.Int(nullable: false, identity: true),
                        HomeTeamGoals = c.Int(nullable: false),
                        AwayTeamGoals = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchScoreId)
                .ForeignKey("dbo.DbMatches", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.MatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbMatchScores", "MatchId", "dbo.DbMatches");
            DropIndex("dbo.DbMatchScores", new[] { "MatchId" });
            DropTable("dbo.DbMatchScores");
        }
    }
}
