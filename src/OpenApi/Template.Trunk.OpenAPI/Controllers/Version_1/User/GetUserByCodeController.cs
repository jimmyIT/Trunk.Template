using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Net;
using Template.Trunk.Server.Application.Common.ApiSupport;
using Template.Trunk.Server.Application.Handlers.Users.GetByCode;
using Template.Trunk.Shared.Constants.OpenAPI;

namespace Template.Trunk.OpenAPI.Controllers.Version_1.User;

[ApiVersion(ApiSettingsConst.Version.V1_0)]
[Authorize]
[ApiExplorerSettings(GroupName = ApiSettingsConst.Tag.User)]
public class GetUserByCodeController : BaseApiController
{
    private readonly IGetUserByCodeHandler _handler;
    public GetUserByCodeController(IGetUserByCodeHandler handler)
    {
        _handler = handler;
    }

    [HttpGet]
    [MapToApiVersion(ApiSettingsConst.Version.V1_0)]
    [Route($"{ApiSettingsConst.DefaultRoute}/{ApiSettingsConst.Controller.User}{APIRouteConst.User.GetByCode}")]
    [ActionDescription(ActionInfoConst.User.GetByCode.Code)]
    [OpenApiOperation(summary: ActionInfoConst.User.GetByCode.Code, description:ActionInfoConst.User.GetByCode.Description)]
    public async Task<ActionResult<GetUserByCodeResponse>> GetByCodeAsync([FromRoute] string code)
    {
        return await DoActionAsync(() => _handler.DoActionAsync(code), HttpStatusCode.OK);
    }
}
