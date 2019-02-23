using gTarrGames.Shared.Orchestrators;
using gTarrGames.Web.Models;
using System.Web.Mvc;

namespace gTarrGames.Web.Controllers
{
    public class HighScoresController : Controller
    {
        // GET: HighScores
        public ActionResult Index()
        {
            var highScoreOrchestrator = new HighScoreOrchestrator();

            var highScoresModel = new HighScoresModel
            {
                HighScores = highScoreOrchestrator.GetAllHighScores()
            };
        
            return View(highScoresModel);
        }
    }
}