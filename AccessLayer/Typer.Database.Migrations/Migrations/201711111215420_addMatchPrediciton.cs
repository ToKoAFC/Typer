namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addMatchPrediciton : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MatchPredictions",
                c => new
                    {
                        MatchPredictionId = c.Int(nullable: false, identity: true),
                        MatchId = c.Int(nullable: false),
                        MatchScoreId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MatchPredictionId)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.MatchScores", t => t.MatchScoreId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.MatchId)
                .Index(t => t.MatchScoreId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchPredictions", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.MatchPredictions", "MatchScoreId", "dbo.MatchScores");
            DropForeignKey("dbo.MatchPredictions", "MatchId", "dbo.Matches");
            DropIndex("dbo.MatchPredictions", new[] { "UserId" });
            DropIndex("dbo.MatchPredictions", new[] { "MatchScoreId" });
            DropIndex("dbo.MatchPredictions", new[] { "MatchId" });
            DropTable("dbo.MatchPredictions");
        }
    }
}
