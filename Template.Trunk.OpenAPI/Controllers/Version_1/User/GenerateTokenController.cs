using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Template.Trunk.Shared.Constants.OpenAPI;

namespace Template.Trunk.OpenAPI.Controllers.Version_1.User
{
    [ApiVersion(ApiSettingsConst.Version.V1_0)]
    public class GenerateTokenController : BaseUserController
    {
        [HttpPost]
        [MapToApiVersion(ApiSettingsConst.Version.V1_0)]
        [Route($"{ApiSettingsConst.DefaultRoute}/{ApiSettingsConst.Controller.User}{APIRouteConst.User.GenerateToken}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OpenApiOperation($"{ActionInfoConst.User.GenerateToken.Code}", $"{ActionInfoConst.User.GenerateToken.Description}")]
        public async Task<ActionResult<string>> GenerateTokenAsync()
        {
            return string.Empty;
        }
    }
}
