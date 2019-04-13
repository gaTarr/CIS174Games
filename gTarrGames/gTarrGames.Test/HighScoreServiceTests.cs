using AutoMoq;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.Services;
using gTarrGames.Shared.Services.Interfaces;
using gTarrGames.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace gTarrGames.Test
{
    [TestClass]
    public class HighScoreServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();
        private readonly IHighScoreOrchestrator _highScoreOrchestrator = new HighScoreOrchestrator();


        [TestMethod]
        public void IsHighScore_ReturnsTrue_WhenScoreReturnedIsHighScore()
        {
            var id = Guid.NewGuid();
            var highScore = _highScoreOrchestrator.NewHighScore(id, 99);

            var person = CreatePerson(id, highScore);


            _mocker.GetMock<IHighScoreService>()
                .Setup(x => x.HighScore(person));

            var highScoreService = _mocker.Create<HighScoreService>();

            var isHighScore = (highScore == highScoreService.HighScore(person));

            Assert.IsTrue(isHighScore);
        }

        [TestMethod]
        public void IsNotHighScore_ReturnsFalse_WhenScoreReturnedNotHighScore()
        {
            var id = Guid.NewGuid();
            var highScore = _highScoreOrchestrator.NewHighScore(id, 99);
            var lowScore = _highScoreOrchestrator.NewHighScore(id, 65);

            var person = CreatePerson(id, highScore);


            _mocker.GetMock<IHighScoreService>()
                .Setup(x => x.HighScore(person));

            var highScoreService = _mocker.Create<HighScoreService>();

            var isHighScore = (lowScore == highScoreService.HighScore(person));

            Assert.IsFalse(isHighScore);

        }


        private PersonViewModel CreatePerson(Guid id, HighScore hs)
        {
            return new PersonViewModel
            {
                PersonId = id,
                FirstName = "George",
                LastName = "Foreman",
                Gender = "Male",
                Email = "grillingMachine@greg.net",
                PhoneNumber = "1234567890",
                HighScore = hs
            };
        }

    }
}
