using System.Data.Entity;
using Typer.Database.Models;

namespace Typer.Database.Migrations
{
    public class TyperContext : DbContext
    {
        public DbSet<DbTeam> DbTeams { get; set; }
        public DbSet<DbUserRole> DbUserRoles { get; set; }
        public DbSet<DbUser> DbUsers { get; set; }
    }
}
