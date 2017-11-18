using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.Globals;

namespace Typer.Database.Models
{
    public class DbPlayer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlayerId { get; set; }

        public int Number { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
               
        public PlayerPositionEnum Position { get; set; }
        
        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual DbTeam Team { get; set; }
    }
}
