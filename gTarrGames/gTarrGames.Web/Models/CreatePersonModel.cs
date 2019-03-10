using System;
using System.ComponentModel.DataAnnotations;

namespace gTarrGames.Web.Models
{
    public class CreatePersonModel
    {
        [EmailAddress]
        public string Email { get; set; }

    }
}