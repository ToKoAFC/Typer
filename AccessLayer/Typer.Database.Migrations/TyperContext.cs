using System.Data.Entity;
using Typer.Database.Models;

namespace Typer.Database.Migrations
{
    public class TyperContext : DbContext
    {
        public DbSet<DbTeam> DbTeams { get; set; }
        public DbSet<DbUserRole> DbUserRoles { get; set; }
        public DbSet<DbSeason> DbSeasons { get; set; }
        public DbSet<DbGameWeek> DbGameWeeks { get; set; }
        public DbSet<DbMatch> DbMatchs { get; set; }
        public DbSet<DbUser> DbUsers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
