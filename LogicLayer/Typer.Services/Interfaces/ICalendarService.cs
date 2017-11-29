using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Typer.ViewModels.Views.Calendar;

namespace Typer.Services.Interfaces
{
    public interface ICalendarService
    {
        VMCalendarIndex GetCalendarIndex(int seasonId);
        SelectList GetSeasonSelectList();
    }
}
