namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DbMatchPredictionFIx : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MatchPredictions", "MatchScoreId", "dbo.MatchScores");
            DropForeignKey("dbo.MatchPredictions", "MatchId", "dbo.Matches");
            DropIndex("dbo.MatchPredictions", new[] { "MatchId" });
            DropIndex("dbo.MatchPredictions", new[] { "MatchScoreId" });
            RenameColumn(table: "dbo.MatchPredictions", name: "MatchScoreId", newName: "MatchScore_MatchId");
            RenameColumn(table: "dbo.MatchPredictions", name: "MatchId", newName: "DbMatch_MatchId");
            AlterColumn("dbo.MatchPredictions", "DbMatch_MatchId", c => c.Int());
            AlterColumn("dbo.MatchPredictions", "MatchScore_MatchId", c => c.Int());
            CreateIndex("dbo.MatchPredictions", "DbMatch_MatchId");
            CreateIndex("dbo.MatchPredictions", "MatchScore_MatchId");
            AddForeignKey("dbo.MatchPredictions", "MatchScore_MatchId", "dbo.MatchScores", "MatchId");
            AddForeignKey("dbo.MatchPredictions", "DbMatch_MatchId", "dbo.Matches", "MatchId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MatchPredictions", "DbMatch_MatchId", "dbo.Matches");
            DropForeignKey("dbo.MatchPredictions", "MatchScore_MatchId", "dbo.MatchScores");
            DropIndex("dbo.MatchPredictions", new[] { "MatchScore_MatchId" });
            DropIndex("dbo.MatchPredictions", new[] { "DbMatch_MatchId" });
            AlterColumn("dbo.MatchPredictions", "MatchScore_MatchId", c => c.Int(nullable: false));
            AlterColumn("dbo.MatchPredictions", "DbMatch_MatchId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.MatchPredictions", name: "DbMatch_MatchId", newName: "MatchId");
            RenameColumn(table: "dbo.MatchPredictions", name: "MatchScore_MatchId", newName: "MatchScoreId");
            CreateIndex("dbo.MatchPredictions", "MatchScoreId");
            CreateIndex("dbo.MatchPredictions", "MatchId");
            AddForeignKey("dbo.MatchPredictions", "MatchId", "dbo.Matches", "MatchId", cascadeDelete: true);
            AddForeignKey("dbo.MatchPredictions", "MatchScoreId", "dbo.MatchScores", "MatchId", cascadeDelete: true);
        }
    }
}
