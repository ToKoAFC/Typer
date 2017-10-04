using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    public class DbSeason
    {
        public DbSeason()
        {
            GameWeeks = new HashSet<DbGameWeek>();
        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeasonId { get; set; }

        [Range(0, 4)]
        public int StartYear { get; set; }

        [Range(0, 4)]
        public int EndYear { get; set; }

        public virtual ICollection<DbGameWeek> GameWeeks { get; set; }
    }
}
