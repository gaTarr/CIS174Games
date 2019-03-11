using gTarrGames.Domain;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace gTarrGames.Shared.Orchestrators
{
    public class PersonOrchestrator : IPersonOrchestrator
    {
        private readonly GamesContext _gamesContext;

        public PersonOrchestrator()
        {
            _gamesContext = new GamesContext();
        }

        public async Task<int> CreatePerson(PersonViewModel person)
        {
            _gamesContext.Persons.Add(new Person
            {
                PersonId = person.PersonId,
                FirstName = null,
                LastName = null,
                Gender = null,
                Email = person.Email,
                PhoneNumber = null,
                DateCreated = DateTime.Now
            });

            return await _gamesContext.SaveChangesAsync();
        }

        public List<PersonViewModel> GetAllPersons()
        {
            var persons = _gamesContext.Persons.Select(x => new PersonViewModel
            {
                PersonId = x.PersonId,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Gender = x.Gender,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber
            }).ToList();

            return persons;
        }

        public async Task<PersonViewModel> SearchPersonId(PersonViewModel person)
        {

            var personEntity = await _gamesContext.Persons.FindAsync(person.PersonId);


            var viewModel = new PersonViewModel
            {
                PersonId = personEntity.PersonId,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                Gender = personEntity.Gender,
                Email = personEntity.Email,
                PhoneNumber = personEntity.PhoneNumber
            };

            return viewModel;
        }

        //Search person by Id, then update db
        public async Task<bool> UpdatePerson(PersonViewModel person)
        {            
            var updateEntity = await _gamesContext.Persons.FindAsync(person.PersonId);

            if (updateEntity == null)
            {
                return false;
            }

            updateEntity.FirstName = person.FirstName;
            updateEntity.LastName = person.LastName;
            updateEntity.Gender = person.Gender;
            updateEntity.Email = person.Email;
            updateEntity.PhoneNumber = person.PhoneNumber;

            await _gamesContext.SaveChangesAsync();

            return true;
        }
    }
}
