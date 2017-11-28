namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pointsEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DbPoints", "SeasonId", "dbo.Seasons");
            DropForeignKey("dbo.DbPoints", "UserId", "dbo.ApplicationUser");
            DropIndex("dbo.DbPoints", new[] { "SeasonId" });
            DropIndex("dbo.DbPoints", new[] { "UserId" });
            AddColumn("dbo.MatchPredictions", "Points", c => c.Int());
            DropTable("dbo.DbPoints");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DbPoints",
                c => new
                    {
                        PointsId = c.Int(nullable: false, identity: true),
                        SeasonId = c.Int(nullable: false),
                        Points = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PointsId);
            
            DropColumn("dbo.MatchPredictions", "Points");
            CreateIndex("dbo.DbPoints", "UserId");
            CreateIndex("dbo.DbPoints", "SeasonId");
            AddForeignKey("dbo.DbPoints", "UserId", "dbo.ApplicationUser", "Id");
            AddForeignKey("dbo.DbPoints", "SeasonId", "dbo.Seasons", "SeasonId", cascadeDelete: false);
        }
    }
}
