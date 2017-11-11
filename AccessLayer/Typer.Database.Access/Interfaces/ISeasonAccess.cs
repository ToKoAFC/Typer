using System.Collections.Generic;
using Typer.CoreModels.Models.Season;

namespace Typer.Database.Access
{
    public interface ISeasonAccess 
    {
        List<CoreSeason> GetSeasons();
        void AddSeason(CoreNewSeason coreSeason);
    }
}
