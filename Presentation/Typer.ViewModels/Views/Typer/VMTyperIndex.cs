using System.Collections.Generic;
using System.Web.Mvc;
using Typer.ViewModels.Common;

namespace Typer.ViewModels.Views.Typer
{
    public class VMTyperIndex
    {
        public List<VMMatchPrediction> Matches { get; set; }
    }
}
