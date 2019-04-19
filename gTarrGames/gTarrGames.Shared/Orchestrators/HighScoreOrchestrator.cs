using gTarrGames.Domain;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gTarrGames.Shared.Orchestrators
{
    public class HighScoreOrchestrator : IHighScoreOrchestrator
    {
        private readonly GamesContext _gamesContext;

        public HighScoreOrchestrator()
        {
            _gamesContext = new GamesContext();
        }

        //Currently unused - 4/13
        public async Task<int> CreateHighScore(PersonViewModel person, decimal score)
        {
            _gamesContext.HighScores.Add(new HighScore
            {
                HighScoreId = Guid.NewGuid(),
                PersonId = person.PersonId,
                Score = score,
                DateAttained = DateTime.Now
            });

            return await _gamesContext.SaveChangesAsync();

        }

        public HighScoreViewModel CreateHighScore(Guid personID, decimal score)
        {
            var highScoreViewModel = new HighScoreViewModel
            {
                HighScoreId = Guid.NewGuid(),
                PersonId = personID,
                Score = score,
                DateAttained = DateTime.Now
            };

            _gamesContext.HighScores.Add(new HighScore
            {
                HighScoreId = highScoreViewModel.HighScoreId,
                PersonId = highScoreViewModel.PersonId,
                Score = highScoreViewModel.Score,
                DateAttained = highScoreViewModel.DateAttained
            });
            _gamesContext.SaveChanges();

            return highScoreViewModel;
        }

        public List<HighScoreViewModel> GetAllHighScores()
        {
            var highScores = _gamesContext.HighScores.Select(x => new HighScoreViewModel
            {
                HighScoreId = x.HighScoreId,
                PersonId = x.PersonId,
                Score = x.Score,
                DateAttained = x.DateAttained
            }).OrderByDescending(x => x.Score).ToList();

            return highScores;
        }

        //To return high score to HighScore Service - 4/4/19
        public HighScore GetHighScoreId(Guid personId)
        {
            var highScoreEntity = _gamesContext.HighScores
                                               .Where(x => x.PersonId == personId)
                                               .OrderByDescending(x => x.Score)
                                               .FirstOrDefault();

            return highScoreEntity;
        }

        //Takes PersonViewModel and returns HighScore - Currently Unused
        public HighScoreViewModel GetHighScorePersonId(PersonViewModel person)
        {
            var highScoreEntity = _gamesContext.HighScores
                                               .Where(x => x.PersonId == person.PersonId)
                                               .OrderByDescending(x => x.Score)
                                               .FirstOrDefault();

            var viewModel = new HighScoreViewModel
            {
                PersonId = highScoreEntity.PersonId,
                Score = highScoreEntity.Score,
                DateAttained = highScoreEntity.DateAttained
            };

            return viewModel;
        }
        //Created 4/12/19 for GetHighScoresTest ** will be used in real application
        public List<HighScoreViewModel> GetAllScoresPersonId(PersonViewModel person)
        {
            var highScores = _gamesContext.HighScores
                                            .Select(x => new HighScoreViewModel
                                                    {
                                                        HighScoreId = x.HighScoreId,
                                                        PersonId = x.PersonId,
                                                        Score = x.Score,
                                                        DateAttained = x.DateAttained
                                                    })
                                            .Where(x => x.PersonId == person.PersonId)
                                            .OrderByDescending(x => x.Score)
                                            .ToList();

            return highScores;
        }

        public HighScoreViewModel GetHighScorePersonId(string personId)
        {
            var tempId = new Guid(personId);

            var highScoreEntity = _gamesContext.HighScores
                                               .Where(x => x.PersonId == tempId)
                                               .OrderByDescending(x => x.Score)
                                               .FirstOrDefault();

            var viewModel = new HighScoreViewModel
            {
                PersonId = highScoreEntity.PersonId,
                Score = highScoreEntity.Score,
                DateAttained = highScoreEntity.DateAttained
            };

            return viewModel;
        }

        public HighScore NewHighScore(Guid id, decimal score)
        {
            return new HighScore
            {
                HighScoreId = Guid.NewGuid(),
                PersonId = id,
                Score = score,
                DateAttained = DateTime.Now
            };
        }
    }
}
