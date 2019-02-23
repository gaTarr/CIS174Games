using System;

namespace gTarrGames.Shared.ViewModels
{
    public class ProjectMembersViewModel
    {
        public Guid MemberId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
