namespace Typer.Database.Migrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Typer.Database.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TyperContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TyperContext context)
        {
            
        }
    }
}
