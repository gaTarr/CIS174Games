using gTarrGames.Domain;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gTarrGames.Shared.Orchestrators
{
    public class ErrorLogOrchestrator : IErrorLogOrchestrator
    {
        private readonly GamesContext _gamesContext;

        public ErrorLogOrchestrator()
        {
            _gamesContext = new GamesContext();
        }

        public void CreateError(ErrorLogViewModel errorLogViewModel)
        {
            _gamesContext.ErrorLogs.Add(new ErrorLog
            {
                ErrorId = errorLogViewModel.ErrorId,
                ErrorDateTime = errorLogViewModel.ErrorDateTime,
                ErrorMessage = errorLogViewModel.ErrorMessage,
                StackTrace = errorLogViewModel.StackTrace,
                InnerExceptions = errorLogViewModel.InnerExceptions
            });
            _gamesContext.SaveChanges();
        }

        public List<ErrorLogViewModel> GetAllErrors()
        {
            var errors = _gamesContext.ErrorLogs.Select(x => new ErrorLogViewModel
            {
                ErrorId = x.ErrorId,
                ErrorDateTime = x.ErrorDateTime,
                ErrorMessage = x.ErrorMessage,
                StackTrace = x.StackTrace,
                InnerExceptions = x.InnerExceptions
            }).OrderByDescending(x => x.ErrorDateTime).ToList();

            return errors;
        }

        
    }
}
