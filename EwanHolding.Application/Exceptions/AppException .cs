using System.Net;

namespace EwanHolding.Application.Exceptions
{
    /// <summary>
    /// Base class for all "expected" application errors (business rule violations,
    /// not-found lookups, etc). The global exception middleware maps these to the
    /// correct HTTP status code instead of returning a raw 500.
    /// Anything that is NOT an AppException is treated as an unexpected bug and
    /// always returns 500, with details hidden in production.
    /// </summary>
    public abstract class AppException : Exception
    {
        public HttpStatusCode StatusCode { get; }

        protected AppException(string message, HttpStatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    /// <summary>Entity/resource does not exist -> 404 Not Found.</summary>
    public class NotFoundException : AppException
    {
        public NotFoundException(string message) : base(message, HttpStatusCode.NotFound) { }

        public NotFoundException(string entityName, object key)
            : base($"{entityName} with ID {key} was not found.", HttpStatusCode.NotFound) { }
    }

    /// <summary>Request conflicts with existing state (duplicate name/email/display order, etc) -> 409 Conflict.</summary>
    public class ConflictException : AppException
    {
        public ConflictException(string message) : base(message, HttpStatusCode.Conflict) { }
    }

    /// <summary>Input is well-formed but semantically invalid -> 400 Bad Request.</summary>
    public class BadRequestException : AppException
    {
        public BadRequestException(string message) : base(message, HttpStatusCode.BadRequest) { }
    }

    /// <summary>Credentials/authentication failure -> 401 Unauthorized.</summary>
    public class UnauthorizedAppException : AppException
    {
        public UnauthorizedAppException(string message) : base(message, HttpStatusCode.Unauthorized) { }
    }
}