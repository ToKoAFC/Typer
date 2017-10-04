namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeason_GameWeek_Match : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbGameWeeks",
                c => new
                    {
                        MatchWeekId = c.Int(nullable: false, identity: true),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchWeekId)
                .ForeignKey("dbo.DbSeasons", t => t.SeasonId, cascadeDelete: true)
                .Index(t => t.SeasonId);
            
            CreateTable(
                "dbo.DbMatches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        MatchWeekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.DbTeams", t => t.AwayTeamId, cascadeDelete: false)
                .ForeignKey("dbo.DbTeams", t => t.HomeTeamId, cascadeDelete: false)
                .ForeignKey("dbo.DbGameWeeks", t => t.MatchWeekId, cascadeDelete: true)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.MatchWeekId);
            
            CreateTable(
                "dbo.DbSeasons",
                c => new
                    {
                        SeasonId = c.Int(nullable: false, identity: true),
                        StartYear = c.Int(nullable: false),
                        EndYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeasonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbGameWeeks", "SeasonId", "dbo.DbSeasons");
            DropForeignKey("dbo.DbMatches", "MatchWeekId", "dbo.DbGameWeeks");
            DropForeignKey("dbo.DbMatches", "HomeTeamId", "dbo.DbTeams");
            DropForeignKey("dbo.DbMatches", "AwayTeamId", "dbo.DbTeams");
            DropIndex("dbo.DbMatches", new[] { "MatchWeekId" });
            DropIndex("dbo.DbMatches", new[] { "AwayTeamId" });
            DropIndex("dbo.DbMatches", new[] { "HomeTeamId" });
            DropIndex("dbo.DbGameWeeks", new[] { "SeasonId" });
            DropTable("dbo.DbSeasons");
            DropTable("dbo.DbMatches");
            DropTable("dbo.DbGameWeeks");
        }
    }
}
