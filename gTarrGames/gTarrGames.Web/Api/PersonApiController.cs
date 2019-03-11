using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    [Route("api/v1/persons")]
    public class PersonApiController : ApiController
    {
        private readonly PersonOrchestrator _personOrchestrator;

        public PersonApiController()
        {
            _personOrchestrator = new PersonOrchestrator();
        }

        [HttpGet]
        public List<PersonViewModel> GetAllPersons()
        {
            var persons = _personOrchestrator.GetAllPersons();

            return persons;
        }


    }
}
