using System.Net;

namespace Mawred_Task.Common
{
    public class ResponseHandler
    {
        // Standard Success (200 OK)
        public Response<T> Success<T>(T entity, object Meta = null, string message = "Success")
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.OK,
                Succeeded = true,
                Message = message,
                Meta = Meta
            };
        }

        // Resource Created (201 Created)
        public Response<T> Created<T>(T entity, object Meta = null, string message = "Created successfully")
        {
            return new Response<T>()
            {
                Data = entity,
                StatusCode = HttpStatusCode.Created,
                Succeeded = true,
                Message = message,
                Meta = Meta
            };
        }

        public Response<T> NoContent<T>()
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NoContent,
                Succeeded = true,
                Message = "Resource deleted successfully" // or whatever 204 context
            };
        }



        // Bad Request (400) - For general client errors or failed validation
        public Response<T> BadRequest<T>(string Message = "Bad Request", Dictionary<string, string> errors = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Succeeded = false,
                Message = Message,
                Errors = errors // Pass structured errors if validation fails
            };
        }

        // Unauthorized (401) - Authentication failure (user not logged in/no token)
        public Response<T> Unauthorized<T>(string Message = "Authentication failed")
        {

            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                Succeeded = false,
                Message = Message
            };
        }

        // Forbidden (403) - Authorization failure (logged in but lacks permission)
        public Response<T> Forbidden<T>(string Message = "Access forbidden")
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.Forbidden,
                Succeeded = false,
                Message = Message
            };
        }

        // Not Found (404)
        public Response<T> NotFound<T>(string message = "Resource not found")
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.NotFound,
                Succeeded = false,
                Message = message
            };
        }

        // Unprocessable Entity (422) - For validation errors that fail business rules
        public Response<T> UnprocessableEntity<T>(string Message = "Unprocessable Entity", Dictionary<string, string> errors = null)
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.UnprocessableEntity,
                Succeeded = false,
                Message = Message,
                Errors = errors
            };
        }


        public Response<T> InternalServerError<T>(string Message = "An internal server error occurred")
        {
            return new Response<T>()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false,
                Message = Message
            };
        }
        public Response<T> Conflict<T>(string message = "Resource already exists")
        {
            return new Response<T>
            {
                StatusCode = HttpStatusCode.Conflict,
                Succeeded = false,
                Message = message
            };
        }
    }
}
