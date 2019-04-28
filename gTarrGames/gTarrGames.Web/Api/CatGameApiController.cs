using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    public class CatGameApiController : ApiController
    {
        //Will use injection here, once dependency issue debugged.
        private readonly HighScoreOrchestrator _highScoreOrchestrator = new HighScoreOrchestrator();
        private readonly PersonOrchestrator _personOrchestrator = new PersonOrchestrator();


        [Route("api/v1/catGameTopTen")]
        public List<HighScoreViewModel> GetTopTen(string email)
        {
            var personViewModel = _personOrchestrator.SearchPersonEmail(email);

            return _highScoreOrchestrator.GetAllScoresPersonId(personViewModel);
        }

        [Route("api/v1/catGameScore")]
        public HighScoreViewModel PostScore(string email, decimal score)
        {
            var personViewModel = _personOrchestrator.SearchPersonEmail(email);

            return _highScoreOrchestrator.CreateHighScore(personViewModel, score);

        }

    }
}
