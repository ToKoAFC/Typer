using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("MatchPredictions")]
    public class DbMatchPrediction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchPredictionId { get; set; }

        public string UserId { get; set; }

        public int? Points { get; set; }

        [Range(0, int.MaxValue)]
        public int? HomeTeamGoals { get; set; }

        [Range(0, int.MaxValue)]
        public int? AwayTeamGoals { get; set; }

        public int MatchId { get; set; }

        [ForeignKey("MatchId")]
        public virtual DbMatch Match { get; set; }

        [ForeignKey("UserId")]
        public virtual DbAppUser User { get; set; }
    }
}
