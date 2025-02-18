using System.Net;

namespace TechLibrary.Exception
{
    public class ErronOnValidationException : TechLibraryException
    {
        private readonly List<string> _errors;
        public ErronOnValidationException(List<string> errorMessages)
        {
            _errors = errorMessages;
        }
        public override List<string> GetErrorMessages() 
            => _errors;

        public override HttpStatusCode GetStatusCode() 
            => HttpStatusCode.BadRequest;
    }
}
