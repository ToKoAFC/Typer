using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    public class DbAppUser : IdentityUser<string, DbAppUserLogin, DbAppUserRole, DbAppUserClaim>, IUser<string>
    {
        public DbAppUser()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DbAppUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

}