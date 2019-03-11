using System;
using System.ComponentModel.DataAnnotations;

namespace gTarrGames.Web.Models
{
    public class UpdatePersonModel
    {
        public Guid PersonId { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        public string Gender { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

    }
}