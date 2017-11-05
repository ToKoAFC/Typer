namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialize : DbMigration
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
                        MatchDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MatchId)
                .ForeignKey("dbo.DbTeams", t => t.AwayTeamId, cascadeDelete: false)
                .ForeignKey("dbo.DbTeams", t => t.HomeTeamId, cascadeDelete: false)
                .ForeignKey("dbo.DbMatchweeks", t => t.MatchweekId, cascadeDelete: false)
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
                        YearStart = c.Int(nullable: false),
                        YearEnd = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SeasonId);
            
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
            
            CreateTable(
                "dbo.AppRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AppRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AppUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AppUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AppUserRoles", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.AppUserLogins", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.AppUserClaims", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.AppUserRoles", "RoleId", "dbo.AppRoles");
            DropForeignKey("dbo.DbMatchScores", "MatchId", "dbo.DbMatches");
            DropForeignKey("dbo.DbMatchweeks", "SeasonId", "dbo.DbSeasons");
            DropForeignKey("dbo.DbMatches", "MatchweekId", "dbo.DbMatchweeks");
            DropForeignKey("dbo.DbMatches", "HomeTeamId", "dbo.DbTeams");
            DropForeignKey("dbo.DbMatches", "AwayTeamId", "dbo.DbTeams");
            DropIndex("dbo.AppUserLogins", new[] { "UserId" });
            DropIndex("dbo.AppUserClaims", new[] { "UserId" });
            DropIndex("dbo.AppUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AppUserRoles", new[] { "UserId" });
            DropIndex("dbo.DbMatchScores", new[] { "MatchId" });
            DropIndex("dbo.DbMatchweeks", new[] { "SeasonId" });
            DropIndex("dbo.DbMatches", new[] { "MatchweekId" });
            DropIndex("dbo.DbMatches", new[] { "AwayTeamId" });
            DropIndex("dbo.DbMatches", new[] { "HomeTeamId" });
            DropTable("dbo.AppUserLogins");
            DropTable("dbo.AppUserClaims");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.AppUserRoles");
            DropTable("dbo.AppRoles");
            DropTable("dbo.DbMatchScores");
            DropTable("dbo.DbSeasons");
            DropTable("dbo.DbMatchweeks");
            DropTable("dbo.DbTeams");
            DropTable("dbo.DbMatches");
        }
    }
}
