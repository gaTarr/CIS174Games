using gTarrGames.Domain;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.Services;
using gTarrGames.Shared.Services.Interfaces;
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
        private readonly IYourHighScoreService _yourHighScoreService;
        private readonly IHighScoreOrchestrator _highScoreOrchestrator;

        public PersonOrchestrator(IYourHighScoreService yourHighScoreService, IHighScoreOrchestrator highScoreOrchestrator)
        {
            _gamesContext = new GamesContext();
            _yourHighScoreService = yourHighScoreService;
            _highScoreOrchestrator = highScoreOrchestrator;
        }

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
                PhoneNumber = x.PhoneNumber,
                HighScore = x.HighScore
            }).ToList();

            return persons;
        }

        //Created 4/19
        public PersonViewModel SearchPersonEmail(string email)
        {
           var personEntity = _gamesContext.Persons.Where(x => x.Email.StartsWith(email)).FirstOrDefault();

            var personViewModel = new PersonViewModel
            {
                PersonId = personEntity.PersonId,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                Gender = personEntity.Gender,
                Email = personEntity.Email,
                PhoneNumber = personEntity.PhoneNumber,
                HighScore = personEntity.HighScore
            };

            return personViewModel;

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
                PhoneNumber = personEntity.PhoneNumber,
                HighScore = personEntity.HighScore
            };

            return viewModel;
        }

        //created 4/3/19 for api testing
        //public PersonViewModel SearchPersonId2(PersonViewModel person)
        //{
        //    var personEntity = _gamesContext.Persons.Find(person.PersonId);


        //    var viewModel = new PersonViewModel
        //    {
        //        PersonId = personEntity.PersonId,
        //        FirstName = personEntity.FirstName,
        //        LastName = personEntity.LastName,
        //        Gender = personEntity.Gender,
        //        Email = personEntity.Email,
        //        PhoneNumber = personEntity.PhoneNumber,
        //        HighScore = personEntity.HighScore
        //    };

        //    return viewModel;
        //}

        //public async Task<bool> SetNewHighScore(PersonViewModel person, HighScore highScore)
        //{
        //    var personEntity = await _gamesContext.Persons.FindAsync(person.PersonId);
        //    var highScoreEntity = await _gamesContext.HighScores.FindAsync(highScore.HighScoreId);

        //    //Determine if they currently have high score
        //    if (_yourHighScoreService.IsYourHighScore(highScore, person))
        //    {
        //        return false;
        //    }
        //    else //If not, update person to new high score
        //    {
        //        await UpdatePerson(new PersonViewModel
        //        {
        //            PersonId = person.PersonId,
        //            FirstName = person.FirstName,
        //            LastName = person.LastName,
        //            Gender = person.Gender,
        //            Email = person.Email,
        //            PhoneNumber = person.PhoneNumber,
        //            HighScore = highScoreEntity
        //        });

        //        return true;
        //    }

        //}

        //Created 4/10/19 to Process API post
        //public async Task<PersonViewModel> SetNewHighScore(string email, decimal score)
        //{
        //    var personEntity = await _gamesContext.Persons.Where(x => x.Email.StartsWith(email)).FirstOrDefaultAsync();
        //    var highScoreEntity = _highScoreOrchestrator.NewHighScore(personEntity.PersonId, score);
        //    var personViewModel = new PersonViewModel
        //    {
        //        PersonId = personEntity.PersonId,
        //        FirstName = personEntity.FirstName,
        //        LastName = personEntity.LastName,
        //        Gender = personEntity.Gender,
        //        Email = personEntity.Email,
        //        PhoneNumber = personEntity.PhoneNumber,
        //        HighScore = personEntity.HighScore
        //    };

        //    if (_yourHighScoreService.IsYourHighScore(highScoreEntity, personViewModel))
        //    {
        //        return personViewModel;
        //    }
        //    else //If not, update person to new high score
        //    {
        //       await UpdatePerson(new PersonViewModel
        //        {
        //            PersonId = personEntity.PersonId,
        //            FirstName = personEntity.FirstName,
        //            LastName = personEntity.LastName,
        //            Gender = personEntity.Gender,
        //            Email = personEntity.Email,
        //            PhoneNumber = personEntity.PhoneNumber,
        //            HighScore = highScoreEntity
        //        });

        //        return personViewModel;

        //    }

        //}
        //Duplicated 4/12 to work with async CreateHighScore
        public async Task<PersonViewModel> SetNewHighScoreAsync(string email, decimal score)
        {
            var personEntity = await _gamesContext.Persons.Where(x => x.Email.StartsWith(email)).FirstOrDefaultAsync();
            var highScoreViewModel = _highScoreOrchestrator.CreateHighScore(personEntity.PersonId, score);
            var personViewModel = new PersonViewModel
            {
                PersonId = personEntity.PersonId,
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                Gender = personEntity.Gender,
                Email = personEntity.Email,
                PhoneNumber = personEntity.PhoneNumber,
                HighScore = personEntity.HighScore
            };
            var highScore = new HighScore
            {
                HighScoreId = highScoreViewModel.HighScoreId,
                PersonId = highScoreViewModel.PersonId,
                Score = highScoreViewModel.Score,
                DateAttained = highScoreViewModel.DateAttained
            };

            if (_yourHighScoreService.IsYourHighScore(highScore, personViewModel))
            {
                return personViewModel;
            }
            else //If not, update person to new high score
            {
                await UpdatePersonAsync(new PersonViewModel
                {
                    PersonId = personEntity.PersonId,
                    FirstName = personEntity.FirstName,
                    LastName = personEntity.LastName,
                    Gender = personEntity.Gender,
                    Email = personEntity.Email,
                    PhoneNumber = personEntity.PhoneNumber,
                    HighScore = highScore
                });

                return personViewModel;

            }

        }
        //Non Threaded version 4/19 - just for Unit testing
        public PersonViewModel SetNewHighScore(PersonViewModel person, decimal score)
        {
            var highScore = new HighScore
            {
                HighScoreId = Guid.NewGuid(),
                PersonId = person.PersonId,
                Score = score,
                DateAttained = DateTime.Now
            };

            if (score >= person.HighScore.Score)
            {
                return new PersonViewModel
                {
                    PersonId = person.PersonId,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    Email = person.Email,
                    PhoneNumber = person.PhoneNumber,
                    HighScore = highScore
                };
            }
            else
            {
                return person;
            }
        }

        public bool UpdatePerson(PersonViewModel person)
        {
            var updateEntity = _gamesContext.Persons.Find(person.PersonId);

            if (updateEntity == null)
            {
                return false;
            }
            else
            {
                updateEntity.FirstName = person.FirstName;
                updateEntity.LastName = person.LastName;
                updateEntity.Gender = person.Gender;
                updateEntity.Email = person.Email;
                updateEntity.PhoneNumber = person.PhoneNumber;
                updateEntity.HighScore = person.HighScore;

                _gamesContext.SaveChanges();
            }

            return true;
        }

        //Search person by Id, then update db. Changed name to UpdatePersonAsync 4/19
        public async Task<bool> UpdatePersonAsync(PersonViewModel person)
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
            updateEntity.HighScore = person.HighScore;

            await _gamesContext.SaveChangesAsync();

            return true;
        }
    }
}
