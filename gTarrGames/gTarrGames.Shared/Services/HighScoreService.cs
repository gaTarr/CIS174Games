using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.Services.Interfaces;
using gTarrGames.Shared.ViewModels;
using System;

namespace gTarrGames.Shared.Services
{
    public class HighScoreService : IHighScoreService
    {
        //This method simply returns the user's high score
        public HighScore HighScore(PersonViewModel person)
        {
            return person.HighScore;
        }
    }
}
