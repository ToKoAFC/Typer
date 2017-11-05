using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("AppUserLogins")]
    public class DbAppUserLogin : IdentityUserLogin<string>
    {
    }
}