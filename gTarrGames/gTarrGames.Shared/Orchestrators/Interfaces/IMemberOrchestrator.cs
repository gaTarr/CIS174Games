using gTarrGames.Shared.ViewModels;
using System.Collections.Generic;

namespace gTarrGames.Shared.Orchestrators.Interfaces
{
    public interface IMemberOrchestrator
    {
        List<ProjectMemberViewModel> GetProjectMembers();
    }
}
