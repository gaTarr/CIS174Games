using System.Web.Mvc;
using System;
using gTarrGames.Shared.Orchestrators;
using System.Text;
using gTarrGames.Shared.ViewModels;

namespace gTarrGames.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ErrorLogOrchestrator _errorLogOrchestrator = new ErrorLogOrchestrator();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "This site was created by a team of one.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ErrorGenerator()
        {
            return View();
        }

        public ActionResult GenerateError()
        {
            try
            {
                throw new System.OutOfMemoryException();
            }
            catch(System.OutOfMemoryException exception)
            {
                string innerEx = "None";
                if (exception.InnerException != null)
                {
                    innerEx = exception.InnerException.ToString();
                }

                _errorLogOrchestrator.CreateError(new ErrorLogViewModel
                {
                    ErrorId = Guid.NewGuid(),
                    ErrorDateTime = DateTime.Now,
                    ErrorMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    InnerExceptions = innerEx
                });
            }
            return View("Shared/Error");
            
        }
    }
}