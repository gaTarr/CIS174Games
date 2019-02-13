using gTarrGames.Domain;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace gTarrGames.Shared.Orchestrators
{
    public class PersonOrchestrator
    {
        private readonly GamesContext _gamesContext;

        public PersonOrchestrator()
        {
            _gamesContext = new GamesContext();
        }

        public List<PersonViewModel> GetAllPersons()
        {
            var persons = _gamesContext.Persons.Select(x => new PersonViewModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                DateCreated = x.DateCreated,
                Email = x.Email
            }).ToList();

            return persons;
        }
    }
}
