using System.Linq;
using System.Web.Mvc;
using Typer.CoreModels.Models.Season;
using Typer.Database.Access;
using Typer.Services.Interfaces;
using Typer.ViewModels.Common;
using Typer.ViewModels.Views.AdminSeason;

namespace Typer.Services.AdminSeason
{
    public class AdminSeasonService : IAdminSeasonService
    {
        private readonly ISeasonAccess _seasonAccess;
        public AdminSeasonService(ISeasonAccess seasonAccess)
        {
            _seasonAccess = seasonAccess;
        }

        public VMAdminSeasonIndex GetAdminSeasonIndex()
        {
            var coreSesons = _seasonAccess.GetSeasons();
            var vmSeasons = coreSesons.Select(x => new VMSeason
            {
                SeasonId = x.SeasonId,
                StartYear = x.StartYear,
                EndYear = x.EndYear
            }).ToList();
            var model = new VMAdminSeasonIndex
            {
                Seasons = vmSeasons
            };
            return model;
        }

        public void AddNewSeason(VMAdminSeasonCreate season)
        {
            var coreModel = new CoreNewSeason
            {
                StartYear = season.StartYear,
                EndYear = season.EndYear
            };
            _seasonAccess.AddSeason(coreModel);
        }

        public SelectList GetSeasonSelectList()
        {
            var coreSesons = _seasonAccess.GetSeasons();
            var selectListItems = coreSesons.Select(x => new SelectListItem
            {
                Value = x.SeasonId.ToString(),
                Text = $"{x.StartYear}/{x.EndYear}"
            });
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
