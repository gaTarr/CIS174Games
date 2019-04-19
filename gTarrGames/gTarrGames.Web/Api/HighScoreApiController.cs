using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    //[Route("api/v1/highScores")]
    public class HighScoreApiController : ApiController
    {
        private readonly HighScoreOrchestrator _highScoreOrchestrator = new HighScoreOrchestrator();


        //[HttpGet]
        [Route("api/v1/highScores")]
        public List<HighScoreViewModel> GetAllHighScores()
        {
            var highScores = _highScoreOrchestrator.GetAllHighScores();

            return highScores;
        }

        [Route("api/v1/yourHighScores")]
        public List<HighScoreViewModel> GetAllYourHighScores()
        {
            var person = new PersonViewModel
            {
                PersonId = Guid.Parse("d5e16be2-f13d-47cc-8cd7-ff5f214c2f37"),
                FirstName = "testFirst",
                LastName = "testLast",
                Email = "testEmail@email.com",
                PhoneNumber = "1234567890"
            };
            var highScores = _highScoreOrchestrator.GetAllScoresPersonId(person);

            return highScores;
        }

    }
}
