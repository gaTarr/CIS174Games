using gTarrGames.Domain.Entities;
using gTarrGames.Shared.ViewModels;

namespace gTarrGames.Shared.Services.Interfaces
{
    public interface IYourHighScoreService
    {
        bool IsYourHighScore(HighScore highScore, PersonViewModel person);
    }
}
