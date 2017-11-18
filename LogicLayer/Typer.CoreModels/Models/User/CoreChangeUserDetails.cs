﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.CoreModels.Models
{
    public class CoreChangeUserDetails
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? FavoriteTeamId { get; set; }
        public string Email { get; set; }
    }
}
