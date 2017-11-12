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
        
        public virtual DbMatchScore MatchScore { get; set; }
        
        [ForeignKey("UserId")]
        public virtual DbAppUser User { get; set; }
    }
}
