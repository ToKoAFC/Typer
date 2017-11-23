using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.Statistic;

namespace Typer.Database.Access
{
    public interface IPointsAccess
    {
        List<CoreUserStatistic> GetUserStatistic(int seasonId, string userId);
    }
}
