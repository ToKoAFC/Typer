using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Typer.Database.Models;

namespace Typer.Database.Migrations
{
    public class TyperContext : IdentityDbContext<DbAppUser, DbAppRole, string, DbAppUserLogin, DbAppUserRole, DbAppUserClaim>
    {
        public DbSet<DbTeam> DbTeams { get; set; }
        public DbSet<DbSeason> DbSeasons { get; set; }
        public DbSet<DbMatchweek> DbMatchweeks { get; set; }
        public DbSet<DbMatch> DbMatchs { get; set; }
        public DbSet<DbMatchScore> DbScores { get; set; }
        public virtual IQueryable<DbAppUser> Users
        {
            get { return base.Users; }
        }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;

            var user = builder.Entity<DbAppUser>().ToTable("ApplicationUser");

            user.HasMany(u => u.Roles).WithRequired().HasForeignKey(ur => ur.UserId);
            user.HasMany(u => u.Claims).WithRequired().HasForeignKey(uc => uc.UserId);
            user.HasMany(u => u.Logins).WithRequired().HasForeignKey(ul => ul.UserId);
            user.Property(u => u.UserName).IsRequired();

            builder.Entity<DbAppUserRole>()
                .HasKey(r => new { r.UserId, r.RoleId });

            builder.Entity<DbAppUserLogin>()
                .HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey });

            builder.Entity<DbAppUserClaim>();

            var role = builder.Entity<DbAppRole>();
            role.Property(r => r.Name).IsRequired();
            role.HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        }

        public static TyperContext Create()
        {
            return new TyperContext();
        }
    }
}
