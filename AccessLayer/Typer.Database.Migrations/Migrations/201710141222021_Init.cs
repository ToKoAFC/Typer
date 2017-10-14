namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbMatches",
                c => new
                    {
                        MatchId = c.Int(nullable: false, identity: true),
                        HomeTeamId = c.Int(nullable: false),
                        AwayTeamId = c.Int(nullable: false),
                        MatchweekId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.DbTeams", t => t.AwayTeamId, cascadeDelete: false)
                .ForeignKey("dbo.DbTeams", t => t.HomeTeamId, cascadeDelete: false)
                .ForeignKey("dbo.DbMatchweeks", t => t.MatchweekId, cascadeDelete: true)
                .Index(t => t.HomeTeamId)
                .Index(t => t.AwayTeamId)
                .Index(t => t.MatchweekId);
            
            CreateTable(
                "dbo.DbTeams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.DbMatchweeks",
                c => new
                    {
                        MatchweekId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SeasonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatchweekId)
                .ForeignKey("dbo.DbSeasons", t => t.SeasonId, cascadeDelete: true)
                .Index(t => t.SeasonId);
            
            CreateTable(
                "dbo.DbSeasons",
                c => new
                    {
                        SeasonId = c.Int(nullable: false, identity: true),
                        StartYear = c.Int(nullable: false),
                        EndYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeasonId);
            
            CreateTable(
                "dbo.DbUserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.DbUsers",
                c => new
                    {
                        UserId = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(maxLength: 50),
                        SecondName = c.String(maxLength: 256),
                        Surname = c.String(maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                        UserRoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.DbUserRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbUsers", "UserRoleId", "dbo.DbUserRoles");
            DropForeignKey("dbo.DbMatchweeks", "SeasonId", "dbo.DbSeasons");
            DropForeignKey("dbo.DbMatches", "MatchweekId", "dbo.DbMatchweeks");
            DropForeignKey("dbo.DbMatches", "HomeTeamId", "dbo.DbTeams");
            DropForeignKey("dbo.DbMatches", "AwayTeamId", "dbo.DbTeams");
            DropIndex("dbo.DbUsers", new[] { "UserRoleId" });
            DropIndex("dbo.DbMatchweeks", new[] { "SeasonId" });
            DropIndex("dbo.DbMatches", new[] { "MatchweekId" });
            DropIndex("dbo.DbMatches", new[] { "AwayTeamId" });
            DropIndex("dbo.DbMatches", new[] { "HomeTeamId" });
            DropTable("dbo.DbUsers");
            DropTable("dbo.DbUserRoles");
            DropTable("dbo.DbSeasons");
            DropTable("dbo.DbMatchweeks");
            DropTable("dbo.DbTeams");
            DropTable("dbo.DbMatches");
        }
    }
}
