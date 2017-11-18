using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("Teams")]
    public class DbTeam
    {
        public DbTeam()
        {
            Players = new HashSet<DbPlayer>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string TeamName { get; set; }

        public virtual ICollection<DbPlayer> Players { get; set; }
    }
}
