using AutoMoq;
using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace gTarrGames.Test
{
    //[TestClass]
    //public class SetNewHighScorePersonOrchestratorTest
    //{
    //    private readonly AutoMoqer _mocker = new AutoMoqer();
    //    private readonly HighScoreOrchestrator _highScoreOrchestrator= new HighScoreOrchestrator();
    //    //private readonly PersonOrchestrator _personOrchestrator = new PersonOrchestrator();
    //    private readonly IPersonOrchestrator _personOrchestrator;

    //    public SetNewHighScorePersonOrchestratorTest(IPersonOrchestrator personOrchestrator)
    //    {
    //        _personOrchestrator = personOrchestrator;
    //    }

    //    [TestInitialize]
    //    public void Initialize()
    //    {
    //        //var highScore = CreateHighScore(100);
    //        //var medScore = CreateHighScore(95);
    //        //var lowScore = CreateHighScore(72);
    //        //var person = CreatePerson(medScore);
    //        //string email = "";
    //        //decimal score = 00;

    //        //_mocker.GetMock<IPersonOrchestrator>()
    //        //    .Setup(x => x.SetNewHighScore(email, score))
    //        //    .Returns(CreatePerson(CreateHighScore(100)));

    //    }

    //    [TestMethod]
    //    public void IsNewHighScore_ReturnsTrue_WhenNewScoreReturnedIsHighScore()
    //    {
    //        var highScore = CreateHighScore(100);
    //        var medScore = CreateHighScore(95);
    //        var lowScore = CreateHighScore(72);
    //        var person = CreatePerson(medScore);
    //        string email = "";
    //        decimal score = 00;

    //        //var desiredResult = _mocker.Create<PersonOrchestrator>();
    //        var desired = CreatePerson(highScore);

    //        var highScoreResult = _personOrchestrator.SetNewHighScore(email, highScore.Score);

    //        Assert.AreEqual<PersonViewModel>(desired, highScoreResult);
    //    }


    //    private PersonViewModel CreatePerson(HighScore highScore)
    //    {
    //        return new PersonViewModel
    //        {
    //            PersonId = Guid.Parse("b47f1691-40cb-4e7d-9a03-5cd2f2003e2d"),
    //            FirstName = "Tormund",
    //            LastName = "Giantsbane",
    //            Gender = "Male",
    //            Email = "FreeFolk123@Hardhome.net",
    //            PhoneNumber = "123-456-7890",
    //            HighScore = highScore
    //        };
    //    }

    //    private HighScore CreateHighScore(decimal score)
    //    {
    //       return _highScoreOrchestrator.NewHighScore(Guid.Parse("b47f1691-40cb-4e7d-9a03-5cd2f2003e2d"), score);
    //    }
        
    //}
}
