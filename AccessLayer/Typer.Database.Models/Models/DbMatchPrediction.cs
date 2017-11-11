using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("MatchPredictions")]
    public class DbMatchPrediction
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MatchPredictionId { get; set; }

        public int MatchId { get; set; }

        public int MatchScoreId { get; set; }

        public string UserId { get; set; }

        [ForeignKey("MatchId")]
        public virtual DbMatch Match { get; set; }

        [ForeignKey("MatchScoreId")]
        public virtual DbMatchScore MatchScore { get; set; }
        
        [ForeignKey("UserId")]
        public virtual DbAppUser User { get; set; }
    }
}
