using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gTarrGames.Shared.Orchestrators.Interfaces
{
    public interface IErrorLogOrchestrator
    {
        List<ErrorLogViewModel> GetAllErrors();
        void CreateError(ErrorLogViewModel errorLogViewModel);

    }
}
