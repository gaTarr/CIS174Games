using System.Collections.Generic;
using gTarrGames.Shared.Orchestrators.Interfaces;
using gTarrGames.Shared.ViewModels;

namespace gTarrGames.Shared.Orchestrators
{
    public class MemberOrchestrator : IMemberOrchestrator
    {
        public List<ProjectMemberViewModel> GetProjectMembers()
        {
            var members = new List<ProjectMemberViewModel>
            {
                new ProjectMemberViewModel
                {
                    Name = "Greg Tarr",
                    Email = "gatarr@dmacc.edu",
                    Role = "Creator"
                }
            };

            return members;
        }

    }
}
