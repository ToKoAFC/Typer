namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUser_USerRoles : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.DbUsers", new[] { "UserRoleId" });
            DropTable("dbo.DbUsers");
            DropTable("dbo.DbUserRoles");
        }
    }
}
