﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Typer.Database.Models
{
    [Table("Teams")]
    public class DbTeam
    {
        public DbTeam()
        {
            FavoriteTeamUsers = new HashSet<DbAppUser>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public ICollection<DbAppUser> FavoriteTeamUsers { get; set; }
    }
}
