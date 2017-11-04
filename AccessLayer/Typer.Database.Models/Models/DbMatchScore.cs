using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models.Models
{
    public  class DbMatchScore
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchScoreId { get; set; }

        public int HomeTeamGoals { get; set; }

        public int AwayTeamGoals { get; set; }

        public int MatchId { get; set; }

        [ForeignKey("MatchId")]
        public virtual DbMatch Match { get; set; }
    }
}
