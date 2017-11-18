using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.Globals;

namespace Typer.ViewModels.Common
{
    public class VMPlayer
    {
        public int PlayerId { get; set; }
        public int Number { get; set; }
        public string FirstName { get; set; }
        public PlayerPositionEnum Position { get; set; }
        public string LastName { get; set; }
        public int? TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
