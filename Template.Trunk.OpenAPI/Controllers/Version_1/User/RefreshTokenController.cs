using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using Template.Trunk.Shared.Constants.OpenAPI;

namespace Template.Trunk.OpenAPI.Controllers.Version_1.User
{
    [ApiVersion(ApiSettingsConst.Version.V1_0)]
    public class RefreshTokenController : BaseUserController
    {
        [HttpPost]
        [Route($"{ApiSettingsConst.DefaultRoute}/{ApiSettingsConst.Controller.User}{APIRouteConst.User.RefreshToken}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [OpenApiOperation($"{ActionInfoConst.User.RefreshToken.Code}", $"{ActionInfoConst.User.RefreshToken.Description}")]
        public async Task<ActionResult<string>> RefreshTokenAsync()
        {
            return string.Empty;
        }
    }
}
