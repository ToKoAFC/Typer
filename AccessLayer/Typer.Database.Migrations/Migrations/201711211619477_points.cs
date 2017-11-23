namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class points : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.PointsId)
                .ForeignKey("dbo.Seasons", t => t.SeasonId, cascadeDelete: false)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.SeasonId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DbPoints", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.DbPoints", "SeasonId", "dbo.Seasons");
            DropIndex("dbo.DbPoints", new[] { "UserId" });
            DropIndex("dbo.DbPoints", new[] { "SeasonId" });
            DropTable("dbo.DbPoints");
        }
    }
}
