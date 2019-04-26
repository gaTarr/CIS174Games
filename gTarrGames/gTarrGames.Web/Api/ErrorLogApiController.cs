using gTarrGames.Domain;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    public class ErrorLogApiController : ApiController
    {
        private readonly ErrorLogOrchestrator _errorLogOrchestrator = new ErrorLogOrchestrator();


        [Route("api/v1/errors")]
        public List<ErrorLogViewModel> GetAllErrors()
        {
            var errors = _errorLogOrchestrator.GetAllErrors();

            return errors;
        }
    }
}
