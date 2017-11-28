using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("Seasons")]
    public class DbSeason
    {
        public DbSeason()
        {
            Matchweeks = new HashSet<DbMatchweek>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeasonId { get; set; }
        public int YearStart { get; set; }
        public int YearEnd { get; set; }
        public virtual ICollection<DbMatchweek> Matchweeks { get; set; }
    }
}
