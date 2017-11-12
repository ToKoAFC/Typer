using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("MatchScores")]
    public  class DbMatchScore
    {
        
        public int? HomeTeamGoals { get; set; }

        public int? AwayTeamGoals { get; set; }

        [Key]
        public int MatchId { get; set; }
        
        [ForeignKey("MatchId")]       
        public virtual DbMatch Match { get; set; }
    }
}
