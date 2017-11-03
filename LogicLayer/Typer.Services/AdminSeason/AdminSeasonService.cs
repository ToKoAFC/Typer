using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Typer.CoreModels.Models.Season;
using Typer.Database.Access.Access.Season;
using Typer.ViewModels.AdminSeason;

namespace Typer.Services.AdminSeason
{
    public class AdminSeasonService
    {
        private AdminSeasonAcess _adminSeasonAcess;
        public AdminSeasonService()
        {
            _adminSeasonAcess = new AdminSeasonAcess();
        }

        public VMAdminSeasonIndex GetAdminSeasonIndex()
        {
            var coreSesons = _adminSeasonAcess.GetSeasons();
            var vmSeasons = coreSesons.Select(x => new VMAdminSeasonIndexSeason
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

        public void AddNewSeason(VMAdminSeasonAddNewSeason season)
        {
            var coreModel = new CoreNewSeason
            {
                StartYear = season.StartYear,
                EndYear = season.EndYear
            };
            _adminSeasonAcess.AddSeason(coreModel);
        }

        public SelectList GetSeasonSelectList()
        {
            var coreSesons = _adminSeasonAcess.GetSeasons();
            var selectListItems = coreSesons.Select(x => new SelectListItem
            {
                Value = x.SeasonId.ToString(),
                Text = $"{x.StartYear}/{x.EndYear}"
            });
            return new SelectList(selectListItems, "Value", "Text");
        }
    }
}
