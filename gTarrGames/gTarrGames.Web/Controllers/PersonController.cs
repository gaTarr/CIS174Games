﻿using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;
using gTarrGames.Web.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace gTarrGames.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonOrchestrator _personOrchestrator;

        public PersonController(IPersonOrchestrator personOrchestrator)
        {
            _personOrchestrator = personOrchestrator;
        }

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Update()
        {
            var sesId = (string)Session["LoginId"];

            var tempViewModel = new PersonViewModel
            {
                PersonId = new Guid(sesId),
                FirstName = null,
                LastName = null,
                Gender = null,
                Email = null,
                PhoneNumber = null,
                HighScore = null
            };

            var personViewModel = await _personOrchestrator.SearchPersonId(tempViewModel);

            return View(personViewModel);
        }

        public async Task<JsonResult> UpdatePerson(UpdatePersonModel person)
        {
            var sesId = (string)Session["LoginId"];

            if (person.PersonId == Guid.Empty)
                return Json(false, JsonRequestBehavior.AllowGet);

            var result = await _personOrchestrator.UpdatePersonAsync(new PersonViewModel
            {
                PersonId = new Guid(sesId),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}