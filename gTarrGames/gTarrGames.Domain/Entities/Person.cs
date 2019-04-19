using System;
using System.ComponentModel.DataAnnotations;

namespace gTarrGames.Domain.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateCreated { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public HighScore HighScore { get; set; }
    }
}
