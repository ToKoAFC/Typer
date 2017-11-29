using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    [Table("Matches")]
    public class DbMatch
    {
        public DbMatch()
        {
            MatchPredictions = new HashSet<DbMatchPrediction>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchId { get; set; }

        public int HomeTeamId { get; set; }

        public int AwayTeamId { get; set; }

        public int MatchweekId { get; set; }

        [Range(0,int.MaxValue)]
        public int? HomeTeamGoals { get; set; }

        [Range(0,int.MaxValue)]
        public int? AwayTeamGoals { get; set; }

        //public bool IsScoreChanged { get; set; }

        public DateTime MatchDate { get; set; }
        
        [ForeignKey("MatchweekId")]
        public virtual DbMatchweek Matchweek { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual DbTeam HomeTeam { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual DbTeam AwayTeam { get; set; }

        public virtual ICollection<DbMatchPrediction> MatchPredictions { get; set; }
    }
}
