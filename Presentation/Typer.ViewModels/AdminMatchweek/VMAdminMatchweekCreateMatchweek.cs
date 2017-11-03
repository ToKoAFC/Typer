using System.Web.Mvc;

namespace Typer.ViewModels.AdminMatchweek
{
    public class VMAdminMatchweekCreate
    {
        public string MatchweekName { get; set; }
        public int SeasonId { get; set; }
        public SelectList Seasons { get; set; }
    }
}