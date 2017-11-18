using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    [Table("AppUsers")]
    public class DbAppUser : IdentityUser
    {
        public DbAppUser()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int? FavoriteTeamId { get; set; }

        [ForeignKey("FavoriteTeamId")]
        public virtual DbTeam FavoriteTeam { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DbAppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}