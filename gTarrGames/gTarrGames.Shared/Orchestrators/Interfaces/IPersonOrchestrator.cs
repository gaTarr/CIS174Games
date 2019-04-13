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
        Task<bool> UpdatePerson(PersonViewModel person);
        //Task<bool> SetNewHighScore(PersonViewModel person, HighScore highScore);
        Task<PersonViewModel> SetNewHighScore(string email, decimal score);
        //PersonViewModel SearchPersonId2(PersonViewModel person);
    }
}
