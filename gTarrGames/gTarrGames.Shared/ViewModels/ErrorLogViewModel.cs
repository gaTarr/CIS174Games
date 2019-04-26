using System;

namespace gTarrGames.Shared.ViewModels
{
    public class ErrorLogViewModel
    {
        public Guid ErrorId { get; set; }
        public string ErrorIdString => ErrorId.ToString();
        public DateTime ErrorDateTime { get; set; }
        public string ErrorMessage { get; set; }
        public string StackTrace { get; set; }
        public string InnerExceptions { get; set; }
    }
}
