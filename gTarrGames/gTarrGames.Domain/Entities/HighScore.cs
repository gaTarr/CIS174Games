﻿using System;

namespace gTarrGames.Domain.Entities
{
    public class HighScore
    {
        public Guid HighScoreId { get; set; }
        public Guid PersonId { get; set; }
        public decimal Score { get; set; }
        public DateTime DateAttained { get; set; }
    }
}
