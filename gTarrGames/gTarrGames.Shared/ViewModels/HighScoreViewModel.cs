using System;

namespace gTarrGames.Shared.ViewModels
{
    public class HighScoreViewModel
    {
        public Guid HighScoreId { get; set; }
        public Guid PersonId { get; set; }
        public string PersonIdString => PersonId.ToString(); //Get name from person entity to display here. For now, display id as placeholder.
        public decimal Score { get; set; }
        public string ScoreString => Score.ToString();
        public DateTime DateAttained { get; set; }
    }
}
