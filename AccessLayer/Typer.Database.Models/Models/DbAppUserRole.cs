using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("AppUserRoles")]
    public class DbAppUserRole : IdentityUserRole<string>
    {
        public virtual DbAppRole Role { get; set; }
    }
}