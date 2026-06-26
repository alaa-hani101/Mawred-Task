using Mawred_Task.Common;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Mawred_Task.Controllers.Base
{
    public class AppControllerBase : ControllerBase
    {
        protected IActionResult NewResult<T>(Response<T> response)
        {
            if (response == null)
            {
                // Should not happen, but defensive check for null
                return StatusCode((int)HttpStatusCode.InternalServerError,
                                  new Response<object> { Message = "An unexpected error occurred: Null response from pipeline." });
            }

            // 2. Map based on the StatusCode property
            return response.StatusCode switch
            {
                // Success Responses (2xx)
                HttpStatusCode.OK => Ok(response), // 200: Successful retrieval or update without new resource
                HttpStatusCode.Created => StatusCode((int)HttpStatusCode.Created, response), // 201: Successful creation of a new resource (e.g., AddStudent)
                HttpStatusCode.Accepted => Accepted(response), // 202: Request accepted for processing (e.g., long-running export job started)
                HttpStatusCode.NoContent => NoContent(), // 204: Successful operation with no content to return (e.g., Deactivate/Delete)

                // Client Error Responses (4xx)
                HttpStatusCode.BadRequest => BadRequest(response), // 400: Generic client error (e.g., missing required fields, Identity password errors)
                HttpStatusCode.Unauthorized => Unauthorized(response), // 401: Authentication required/failed (e.g., login failure)
                HttpStatusCode.Forbidden => Forbid(), // 403: Authorized user lacks necessary permissions (e.g., Teacher tries to deactivate a student)
                HttpStatusCode.NotFound => NotFound(response), // 404: Resource not found (e.g., GetByCodeAsync failed)

                // 409: Conflict indicates a resource already exists (e.g., trying to create a user with an existing email)
                HttpStatusCode.Conflict => Conflict(response),

                // 422: Unprocessable Entity is often used for business logic validation failures 
                // (e.g., FluentValidation pipeline or specific business rule violation like an existing student code)
                (HttpStatusCode)422 => UnprocessableEntity(response),

                // Server Error Responses (5xx)
                HttpStatusCode.InternalServerError => StatusCode((int)HttpStatusCode.InternalServerError, response), // 500: Database save failure, unhandled exceptions

                // Default fallback
                _ => StatusCode((int)response.StatusCode, response)
            };
        }

    }
}
