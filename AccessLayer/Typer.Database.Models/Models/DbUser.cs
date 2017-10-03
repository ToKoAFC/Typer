using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    public class DbUser
    {
        public DbUser()
        {
            UserId = new Guid();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserId { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string SecondName { get; set; }

        [StringLength(50)]
        public string Surname { get; set; }

        public bool IsActive { get; set; }

        public bool IsDelete { get; set; }

        public int UserRoleId { get; set; }

        [ForeignKey("UserRoleId")]
        public virtual DbUserRole UserRole { get; set; }
    }
}
