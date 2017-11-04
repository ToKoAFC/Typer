using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Typer.Database.Models;
using Typer.Database.Models.Models;

namespace Typer.Database.Migrations
{
    public class TyperContext : DbContext
    {
        public DbSet<DbTeam> DbTeams { get; set; }
        public DbSet<DbUserRole> DbUserRoles { get; set; }
        public DbSet<DbSeason> DbSeasons { get; set; }
        public DbSet<DbMatchweek> DbMatchweeks { get; set; }
        public DbSet<DbMatch> DbMatchs { get; set; }
        public DbSet<DbUser> DbUsers { get; set; }
        public DbSet<DbMatchScore> DbScores { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
