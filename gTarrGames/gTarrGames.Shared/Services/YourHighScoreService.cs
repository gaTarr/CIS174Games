using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Services.Interfaces;
using gTarrGames.Shared.ViewModels;

namespace gTarrGames.Shared.Services
{
    public class YourHighScoreService : IYourHighScoreService
    {
        private readonly IHighScoreService _highScoreService;

        public YourHighScoreService(IHighScoreService highScoreService)
        {
            _highScoreService = highScoreService;
        }

        public bool IsYourHighScore(HighScore highScore, PersonViewModel person)
        {
            return highScore.Score >= _highScoreService.HighScore(person).Score;
        }
    }
}
