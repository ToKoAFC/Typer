using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    public class DbMatchweek
    {
        public DbMatchweek()
        {
            Matches = new HashSet<DbMatch>();
            SeasonId = 1;
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
