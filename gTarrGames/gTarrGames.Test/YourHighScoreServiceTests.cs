using AutoMoq;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Services;
using gTarrGames.Shared.Services.Interfaces;
using gTarrGames.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace gTarrGames.Test
{
    [TestClass]
    public class YourHighScoreServiceTests
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();
        private readonly HighScoreOrchestrator _highScoreOrchestrator = new HighScoreOrchestrator();


        [TestMethod]
        public void HighScore_ReturnsTrue_WhenHighScoreIsNewHighScore()
        {
            var id = Guid.NewGuid();
            var highScore = _highScoreOrchestrator.NewHighScore(id, 99);

            var person = CreatePerson(id, highScore);

            _mocker.GetMock<IHighScoreService>()
                .Setup(x => x.HighScore(person))
                .Returns(highScore);

            var yourHighScoreService = _mocker.Create<YourHighScoreService>();

            var isHighScore = yourHighScoreService.IsYourHighScore(highScore, person);

            Assert.IsTrue(isHighScore);
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
