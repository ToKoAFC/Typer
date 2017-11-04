namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typercontext : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbMatches", "MatchDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DbMatches", "MatchDate");
        }
    }
}
