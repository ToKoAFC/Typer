namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Remove_Int_Range : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DbSeasons", "YearStart", c => c.Int(nullable: false));
            AddColumn("dbo.DbSeasons", "YearEnd", c => c.Int(nullable: false));
            DropColumn("dbo.DbSeasons", "StartYear");
            DropColumn("dbo.DbSeasons", "EndYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DbSeasons", "EndYear", c => c.Int(nullable: false));
            AddColumn("dbo.DbSeasons", "StartYear", c => c.Int(nullable: false));
            DropColumn("dbo.DbSeasons", "YearEnd");
            DropColumn("dbo.DbSeasons", "YearStart");
        }
    }
}
