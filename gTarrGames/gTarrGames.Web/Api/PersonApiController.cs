﻿using gTarrGames.Domain.Entities;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    
    public class PersonApiController : ApiController
    {
        private readonly PersonOrchestrator _personOrchestrator = new PersonOrchestrator();
        private readonly HighScoreOrchestrator _highScoreOrchestrator = new HighScoreOrchestrator();

        //Still need to diagnose issue with injection here.  Recent but prevents injection 4/27/19
        //private readonly IPersonOrchestrator _personOrchestrator;
        //private readonly IHighScoreOrchestrator _highScoreOrchestrator;

        //public PersonApiController(IPersonOrchestrator personOrchestrator, IHighScoreOrchestrator highScoreOrchestrator)
        //{
        //    _personOrchestrator = personOrchestrator;
        //    _highScoreOrchestrator = highScoreOrchestrator;
        //}


        [Route("api/v1/persons")]
        public List<PersonViewModel> GetAllPersons()
        {
            var persons = _personOrchestrator.GetAllPersons();

            return persons;
        }

        [Route("api/v1/personSetScore")]
        public Task<PersonViewModel> NewHighScore(string email, decimal score)
        {
            
            return _personOrchestrator.SetNewHighScoreAsync(email, score);
        }
    }
}
