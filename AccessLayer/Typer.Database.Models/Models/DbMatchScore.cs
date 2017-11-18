using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("MatchScores")]
    public  class DbMatchScore
    {
        [Range(0, int.MaxValue)]
        public int? HomeTeamGoals { get; set; }

        [Range(0,int.MaxValue)]
        public int? AwayTeamGoals { get; set; }

        [Key]
        public int MatchId { get; set; }
        
        [ForeignKey("MatchId")]       
        public virtual DbMatch Match { get; set; }
    }
}
