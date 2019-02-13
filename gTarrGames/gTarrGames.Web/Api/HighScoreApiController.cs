using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    [Route("api/v1/highScores")]
    public class HighScoreApiController : ApiController
    {
        private readonly HighScoreOrchestrator _highScoreOrchestrator;

        public HighScoreApiController()
        {
            _highScoreOrchestrator = new HighScoreOrchestrator();
        }

        [HttpGet]
        public List<HighScoreViewModel> GetAllHighScores()
        {
            var highScores = _highScoreOrchestrator.GetAllHighScores();

            return highScores;
        }
    }
}
