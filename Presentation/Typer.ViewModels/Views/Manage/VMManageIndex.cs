using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Typer.ViewModels.Views.Manage
{
    public class VMManageIndex
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int FavoriteTeamId { get; set; }
        public SelectList SelectListTeams { get; set; }
    }
}
