using System.Web.Mvc;
using gTarrGames.Shared.Orchestrators;
using gTarrGames.Web.Models;

namespace gTarrGames.Web.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        public ActionResult Index()
        {
            var projMemberOrchestrator = new MemberOrchestrator();

            var membersModel = new MembersModel
            {
                Members = projMemberOrchestrator.GetProjectMembers(),
            };

            return View(membersModel);
        }
    }
}