using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Polly;
using System.Net;
using Template.Trunk.Server.Application.Common.Domain;

namespace Template.Trunk.OpenAPI.Controllers
{
    [ApiController]
    public class BaseApiController : Controller
    {
        internal async Task<ActionResult<T>> DoActionAsync<T>(
            Func<Task<ApiActionResult<T>>> func,
            HttpStatusCode successStatusCode)
        {
            ApiActionResult<T> response = await Policy.Handle<SqlException>()
                                                      .WaitAndRetryAsync(3, retryAttemp => TimeSpan.FromSeconds(5))
                                                      .ExecuteAsync(async () =>
                                                      {
                                                          return await func();
                                                      });

            return successStatusCode switch
            {
                HttpStatusCode.OK => Ok200Async(response.Data),
                HttpStatusCode.Created => Created201Async(response.Data),
                HttpStatusCode.NoContent => NoContent204Async(),
                _ => NoContent204Async()
            };
        }

        ActionResult Ok200Async(object? responseData) => Ok(responseData);
        ActionResult BadRequest400Async(object? responseErrors) => BadRequest(responseErrors);
        ActionResult Created201Async(object? responseData) => StatusCode((int)HttpStatusCode.Created, responseData);
        ActionResult NoContent204Async() => NoContent();
    }
}
