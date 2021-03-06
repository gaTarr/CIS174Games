﻿using gTarrGames.Domain.Entities;
using System;

namespace gTarrGames.Shared.ViewModels
{
    public class PersonViewModel
    {
        public Guid PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public HighScore HighScore { get; set; }
    }

}
