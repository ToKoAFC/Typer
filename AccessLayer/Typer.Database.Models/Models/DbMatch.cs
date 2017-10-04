using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    public class DbMatch
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public int MatchWeekId { get; set; }



        [ForeignKey("MatchWeekId")]
        public virtual DbGameWeek MatchWeek { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual DbTeam HomeTeam { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual DbTeam AwayTeam { get; set; }
    }
}
