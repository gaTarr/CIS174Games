using gTarrGames.Domain.Entities;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gTarrGames.Shared.Orchestrators.Interfaces
{
    public interface IPersonOrchestrator
    {
        Task<int> CreatePerson(PersonViewModel person);
        List<PersonViewModel> GetAllPersons();
        Task<PersonViewModel> SearchPersonId(PersonViewModel person);
        PersonViewModel SearchPersonEmail(string email);
        Task<bool> UpdatePersonAsync(PersonViewModel person);
        bool UpdatePerson(PersonViewModel person);
        //Task<bool> SetNewHighScore(PersonViewModel person, HighScore highScore);
        Task<PersonViewModel> SetNewHighScoreAsync(string email, decimal score);
        PersonViewModel SetNewHighScore(PersonViewModel person, decimal score);
        //PersonViewModel SearchPersonId2(PersonViewModel person);
    }
}
