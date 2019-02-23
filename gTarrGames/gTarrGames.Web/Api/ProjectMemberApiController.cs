using gTarrGames.Shared.Orchestrators;
using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;
using System.Web.Http;

namespace gTarrGames.Web.Api
{
    [Route("api/v1/projectMembers")]
    public class ProjectMemberApiController : ApiController
    {
        private readonly ProjectMemberOrchestrator _projectMemberOrchestrator;

        public ProjectMemberApiController()
        {
            _projectMemberOrchestrator = new ProjectMemberOrchestrator();
        }

        [HttpGet]
        public List<ProjectMembersViewModel> GetProjectMembers()
        {
            var projMembers = _projectMemberOrchestrator.GetProjectMembers();

            return projMembers;
        }
    }
}
