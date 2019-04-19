using gTarrGames.Domain.Entities;
using gTarrGames.Shared.ViewModels;

namespace gTarrGames.Shared.Services.Interfaces
{
    public interface IHighScoreService
    {
        HighScore HighScore(PersonViewModel person);    
    }
}
