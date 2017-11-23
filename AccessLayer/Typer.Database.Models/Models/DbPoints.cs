using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.Database.Models
{
    public class DbPoints
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PointsId { get; set; }
        public int SeasonId { get; set; }
        public int Points { get; set; }
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual DbAppUser User { get; set; }

        [ForeignKey("SeasonId")]
        public virtual DbSeason Season { get; set; }
    }
}
