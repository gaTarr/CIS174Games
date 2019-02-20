using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    [Route("api/v1/members")]
    public class ProjectMemberApiController : ApiController
    {
        private readonly MemberOrchestrator _memberOrchestrator;

        public ProjectMemberApiController()
        {
            _memberOrchestrator = new MemberOrchestrator();
        }

        [HttpGet]
        public List<ProjectMemberViewModel> GetProjectMembers()
        {
            var members = _memberOrchestrator.GetProjectMembers();

            return members;
        }
    }
}
