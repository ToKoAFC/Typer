using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Typer.CoreModels.Models
{
    public class CoreUserDetails
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public CoreTeam FavoriteTeam { get; set; }
        public string Email { get; set; }
    }

}
