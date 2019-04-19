using AutoMoq;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace gTarrGames.Test
{
    [TestClass]
    public class SetNewHighScoreAPITest
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();
        private readonly HighScoreOrchestrator _highScoreOrchestrator = new HighScoreOrchestrator();
        private readonly PersonOrchestrator _personOrchestrator = new PersonOrchestrator();

        [TestMethod]
        public void NewHighScore_ReturnsTrue_WhenNewHighScoreSet()
        {
            var person = CreatePerson(CreateHighScore(2));
            var highScore = CreateHighScore(100);
            var desiredHighScore = 100;


            var newScoreSet = _personOrchestrator.SetNewHighScore(person, highScore.Score);

            Assert.AreEqual(desiredHighScore, newScoreSet.HighScore.Score);
        }

        [TestMethod]
        public void HighScoreNotNewHighScore_ReturnsFalse_WhenScoreNotNewHighScore()
        {
            var person = CreatePerson(CreateHighScore(99));
            var newScore = CreateHighScore(96);
            var desiredHighScore = 96;

            var newScoreSet = _personOrchestrator.SetNewHighScore(person, newScore.Score);

            Assert.AreNotEqual(desiredHighScore, newScoreSet.HighScore.Score);
        }

        private PersonViewModel CreatePerson(HighScore highScore)
        {
            return new PersonViewModel
            {
                PersonId = Guid.Parse("b47f1691-40cb-4e7d-9a03-5cd2f2003e2d"),
                FirstName = "Tormund",
                LastName = "Giantsbane",
                Gender = "Male",
                Email = "FreeFolk123@Hardhome.net",
                PhoneNumber = "123-456-7890",
                HighScore = highScore
            };
        }

        private HighScore CreateHighScore(decimal score)
        {
            return _highScoreOrchestrator.NewHighScore(Guid.Parse("b47f1691-40cb-4e7d-9a03-5cd2f2003e2d"), score);
        }
    }
}
