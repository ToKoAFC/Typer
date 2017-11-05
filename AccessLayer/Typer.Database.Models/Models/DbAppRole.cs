using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("AppRoles")]
    public class DbAppRole : IdentityRole<string, DbAppUserRole>, IRole<string>
    {
        public DbAppRole()
        {
            Id = Guid.NewGuid().ToString();
        }

        public DbAppRole(string name)
            : this()
        {
            this.Name = name;
        }
    }
}
