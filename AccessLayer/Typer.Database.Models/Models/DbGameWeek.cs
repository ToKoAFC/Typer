using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    public class DbGameWeek
    {
        public DbGameWeek()
        {
            Matches = new HashSet<DbMatch>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchWeekId { get; set; }

        public int SeasonId { get; set; }

        [ForeignKey("SeasonId")]
        public virtual DbSeason Season { get; set; }

        public virtual ICollection<DbMatch> Matches { get; set; }
    }
}
