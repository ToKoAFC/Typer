using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Typer.ViewModels.Common;

namespace Typer.ViewModels.Views.Profile
{
    public class VMManageIndex
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public VMTeam FavoriteTeam { get; set; }
        public SelectList SelectListTeams { get; set; }
        public int? FavoriteTeamId { get; set; }
    }
}
