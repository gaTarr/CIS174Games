using System;
using System.ComponentModel.DataAnnotations;

namespace gTarrGames.Domain.Entities
{
    public class ErrorLog
    {
        [Key]
        public Guid ErrorId { get; set; }
        public DateTime ErrorDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerExceptions { get; set; }
    }
}
