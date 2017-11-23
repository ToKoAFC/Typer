using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.CoreModels.Models.Statistic;
using Typer.Database.Migrations;

namespace Typer.Database.Access
{
    public class PointsAccess : IPointsAccess
    {
        private readonly TyperContext _context;
        public PointsAccess()
        {
            _context = new TyperContext();
        }

        public List<CoreUserStatistic> GetUserStatistic(int seasonId, string userId)
        {
            var points = _context.Points.Where(x => x.SeasonId == seasonId && x.UserId == userId).ToList();
            return points.Select(x => new CoreUserStatistic
            {
                Username = x.User.UserName,
                UserPoints = x.Points
            }).ToList();
        }
    }
}
