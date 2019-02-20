using System.Collections.Generic;
using gTarrGames.Domain;
using gTarrGames.Shared.ViewModels;

namespace gTarrGames.Shared.Orchestrators
{
    public class MemberOrchestrator
    {
        private readonly GamesContext _gamesContext;

        public MemberOrchestrator()
        {
            _gamesContext = new GamesContext();
        }

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
