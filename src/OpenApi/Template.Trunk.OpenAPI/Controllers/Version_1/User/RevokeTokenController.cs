using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Template.Trunk.Shared.Constants.OpenAPI;

namespace Template.Trunk.OpenAPI.Controllers.Version_1.User
{
    [ApiVersion(ApiSettingsConst.Version.V1_0)]
    public class RevokeTokenController : BaseUserController
    {
        [HttpPost]
        [Route($"{ApiSettingsConst.DefaultRoute}/{ApiSettingsConst.Controller.User}{APIRouteConst.User.RevokeToken}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OpenApiOperation($"{ActionInfoConst.User.RevokeToken.Code}", $"{ActionInfoConst.User.RevokeToken.Description}")]
        public async Task<ActionResult<string>> RevokeTokenAsync()
        {
            return string.Empty;
        }
    }
}
