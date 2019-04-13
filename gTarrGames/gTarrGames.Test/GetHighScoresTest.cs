using AutoMoq;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace gTarrGames.Test
{
    [TestClass]
    public class GetHighScoresTest
    {
        private readonly AutoMoqer _mocker = new AutoMoqer();
        private readonly HighScoreOrchestrator _highScoreOrchestrator = new HighScoreOrchestrator();

        [TestMethod]
        public void HighScores_ReturnsTrue_WhenHighScoresReturnedByScore()
        {
            var medScore = CreateHighScore(49);
            var highScore = CreateHighScore(50);
            var lowScore = CreateHighScore(48);
            var person = CreatePerson();

            var expected = new List<HighScoreViewModel>()
            {
                highScore,
                medScore,
                lowScore
            };

            //_mocker.GetMock<IHighScoreOrchestrator>()
            //    .Setup(x => x.GetAllScoresPersonId(person))
            //   .Returns(expected);

            //var mockHighScores = _mocker.Create<HighScoreOrchestrator>().GetAllHighScores();

            var highScoresList = _highScoreOrchestrator.GetAllScoresPersonId(person);

            CollectionAssert.AreEqual(expected, highScoresList);

        }

        //[TestMethod]
        //public void HighScores_ReturnsTrue_WhenHighScoresReturnedByScore()
        //{
        //    var medScore = CreateHighScore(49);
        //    var highScore = CreateHighScore(50);
        //    var lowScore = CreateHighScore(48);
        //    var person = CreatePerson();

        //    var expected = new List<HighScore>
        //    {
        //        highScore,
        //        medScore,
        //        lowScore
        //    }.AsQueryable();

        //    var mockSet = new Mock<DbSet<HighScore>>();
        //    mockSet.As<IQueryable<HighScore>>().Setup(m => m.Provider).Returns(expected.Provider);
        //    mockSet.As<IQueryable<HighScore>>().Setup(m => m.Expression).Returns(expected.Expression);
        //    mockSet.As<IQueryable<HighScore>>().Setup(m => m.ElementType).Returns(expected.ElementType);
        //    mockSet.As<IQueryable<HighScore>>().Setup(m => m.GetEnumerator()).Returns(expected.GetEnumerator());

        //    var mockContext = new Mock<GamesContext>();
        //    mockContext.Setup(c => c.HighScores).Returns(mockSet.Object);

        //    //_mocker.GetMock<IHighScoreOrchestrator>()
        //    //    .Setup(x => x.GetAllScoresPersonId(person))
        //    //   .Returns(expected);

        //    //var mockHighScores = _mocker.Create<HighScoreOrchestrator>().GetAllHighScores();

        //    var highScoreOrchestrator = new HighScoreOrchestrator(mockContext.Object);
        //    var highScores = highScoreOrchestrator.GetAllScoresPersonId(person);
        //    //var highScoresList = _highScoreOrchestrator.GetAllScoresPersonId(person);

        //    CollectionAssert.AreEqual(expected., highScoresList);

        //}

        private PersonViewModel CreatePerson()
        {
            return new PersonViewModel
            {
                PersonId = Guid.Parse("b47f1691-40cb-4e7d-9a03-5cd2f2003e2d"),
                FirstName = "Tormund",
                LastName = "Giantsbane",
                Gender = "Male",
                Email = "FreeFolk123@Hardhome.net",
                PhoneNumber = "123-456-7890",
                HighScore = null
            };
        }

        private HighScoreViewModel CreateHighScore(decimal score)
        {
            return _highScoreOrchestrator.CreateHighScore(Guid.Parse("b47f1691-40cb-4e7d-9a03-5cd2f2003e2d"), score);

            //return new HighScore
            //{
            //    HighScoreId = highScoreViewModel.HighScoreId,
            //    PersonId = highScoreViewModel.PersonId,
            //    Score = highScoreViewModel.Score,
            //    DateAttained = highScoreViewModel.DateAttained
            //};

        }

    }
}
