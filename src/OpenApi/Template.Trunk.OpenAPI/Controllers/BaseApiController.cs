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

        ActionResult Ok200Async(object? response) => Ok(response);
        ActionResult BadRequest400Async(object? response) => BadRequest(response);
        ActionResult Created201Async(object? response) => StatusCode((int)HttpStatusCode.Created, response);
        ActionResult NoContent204Async() => NoContent();
    }
}
