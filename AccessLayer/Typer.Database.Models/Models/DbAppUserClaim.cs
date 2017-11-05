using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("AppUserClaims")]
    public class DbAppUserClaim : IdentityUserClaim<string>
    {
    }
}