namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_team : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbTeams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbTeams");
        }
    }
}
