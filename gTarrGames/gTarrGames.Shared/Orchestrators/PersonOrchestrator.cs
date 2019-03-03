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

        //To be called on page load
        public async Task<PersonViewModel> SearchPerson(string searchString)
        {
            var person = await _gamesContext.Persons.Where(x => x.Email.StartsWith(searchString)).FirstOrDefaultAsync();

            if (person == null)
            {
                return new PersonViewModel();
            }

            var viewModel = new PersonViewModel
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            };

            return viewModel;
        }


        //Search for Person by Email - currently unused
        public async Task<PersonViewModel> SearchPersonAsync(string searchString)
        {
            var person = await _gamesContext.Persons.Where(x => x.Email.StartsWith(searchString)).FirstOrDefaultAsync();

            if (person == null)
            {
                return new PersonViewModel();
            }

            var viewModel = new PersonViewModel()
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            };

            return viewModel;
        }

        //Search person by email, then update db
        public async Task<bool> UpdatePerson(PersonViewModel person)
        {
            //var updateEntity = await _gamesContext.Persons.FindAsync(person.PersonId);  --to remove
            var updateEntity = await _gamesContext.Persons.Where(x => x.Email.StartsWith(person.Email.ToString())).FirstOrDefaultAsync();

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
