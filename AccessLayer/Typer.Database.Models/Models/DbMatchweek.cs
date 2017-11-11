using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("Matchweeks")]
    public class DbMatchweek
    {
        public DbMatchweek()
        {
            Matches = new HashSet<DbMatch>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchweekId { get; set; }

        public string Name { get; set; }

        public int SeasonId { get; set; }

        [ForeignKey("SeasonId")]
        public virtual DbSeason Season { get; set; }

        public virtual ICollection<DbMatch> Matches { get; set; }
    }
}
