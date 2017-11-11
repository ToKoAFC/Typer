using System.Collections.Generic;
using Typer.ViewModels.Common;

namespace Typer.Services.Interfaces
{
    public interface ITyperService
    {
        List<VMMatch> GetTyperIndexMatches(int matchweekId);
    }
}
