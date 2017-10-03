using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Typer.Database.Models.Models;

namespace Typer.Database.Migrations
{
    public class TyperContext : DbContext
    {
        public DbSet<DbTeam> DbTeams { get; set; }
    }
}
