using gTarrGames.Domain;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace gTarrGames.Shared.Orchestrators
{
    public class HighScoreOrchestrator
    {
        private readonly GamesContext _gamesContext;

        public HighScoreOrchestrator()
        {
            _gamesContext = new GamesContext();
        }

        public List<HighScoreViewModel> GetAllHighScores()
        {
            var highScores = _gamesContext.HighScores.Select(x => new HighScoreViewModel
            {
                PersonId = x.PersonId,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).ToList();

            return highScores;
        }
    }
}
