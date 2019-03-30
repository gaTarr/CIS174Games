using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Web.Models;
using System.Web.Mvc;

namespace gTarrGames.Web.Controllers
{
    public class HighScoresController : Controller
    {
        private readonly IHighScoreOrchestrator _highScoreOrchestrator;

        public HighScoresController(IHighScoreOrchestrator highScoreOrchestrator)
        {
            _highScoreOrchestrator = highScoreOrchestrator;
        }

        // GET: HighScores
        public ActionResult Index()
        {
            //var highScoreOrchestrator = new HighScoreOrchestrator();

            var highScoresModel = new HighScoresModel
            {
                HighScores = _highScoreOrchestrator.GetAllHighScores()
            };
        
            return View(highScoresModel);
        }
    }
}