using System;

namespace gTarrGames.Shared.ViewModels
{
    public class HighScoreViewModel
    {
        public Guid PersonId { get; set; }
        public decimal Score { get; set; }
        public DateTime DateAttained { get; set; }
    }
}
