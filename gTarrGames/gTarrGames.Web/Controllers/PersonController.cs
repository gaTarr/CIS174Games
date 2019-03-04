using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using gTarrGames.Web.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace gTarrGames.Web.Controllers
{
    public class PersonController : Controller
    {
        private PersonOrchestrator _personOrchestrator = new PersonOrchestrator();
        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Update()
        {
            var sesEmail = (string) Session["LoginEmail"];
            
            var personViewModel = await _personOrchestrator.SearchPerson(sesEmail);
        
            return View(personViewModel);
        }

        //Currently Unused
        public async void CreatePerson(CreatePersonModel person)
        {
             await _personOrchestrator.CreatePerson(new PersonViewModel
            {
                PersonId = Guid.NewGuid(),
                Email = person.Email
            });

        }

        public async Task<JsonResult> UpdatePerson(UpdatePersonModel person)
        {
            if (person.PersonId == Guid.Empty)
                return Json(false, JsonRequestBehavior.AllowGet);

            var result = await _personOrchestrator.UpdatePerson(new PersonViewModel
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                Email = (string) Session["LoginEmail"],
                PhoneNumber = person.PhoneNumber
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //For search Function - currently unused
        public async void Search(string searchString)
        {
            var viewModel = await _personOrchestrator.SearchPersonAsync(searchString);

        }
    }
}