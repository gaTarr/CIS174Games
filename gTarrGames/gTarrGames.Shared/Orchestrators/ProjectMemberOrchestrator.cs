using gTarrGames.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace gTarrGames.Shared.Orchestrators
{
    public class ProjectMemberOrchestrator
    {
        public List<ProjectMembersViewModel> GetProjectMembers()
        {
            var projectMembers = new List<ProjectMembersViewModel>
            {
                new ProjectMembersViewModel
                {
                    MemberId = Guid.Parse("154781a1-93cb-47b8-8471-290f2450de29"),
                    Name = "Greg Tarr",
                    Email = "gatarr@dmacc.edu",
                    Role = "Creator",
                }
            };

            return projectMembers;
        }
    }
}
