using gTarrGames.Domain.Entities;
using gTarrGames.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gTarrGames.Shared.Orchestrators.Interfaces
{
    public interface IHighScoreOrchestrator
    {
        List<HighScoreViewModel> GetAllHighScores();
        List<HighScoreViewModel> GetAllScoresPersonId(PersonViewModel person);
        Task<int> CreateHighScore(PersonViewModel person, decimal score);
        HighScoreViewModel CreateHighScore(Guid personID, decimal score);
        HighScoreViewModel GetHighScorePersonId(PersonViewModel person);
        HighScoreViewModel GetHighScorePersonId(string personId);
        HighScore GetHighScoreId(Guid personId);
        HighScore NewHighScore(Guid id, decimal score);
    }
}
