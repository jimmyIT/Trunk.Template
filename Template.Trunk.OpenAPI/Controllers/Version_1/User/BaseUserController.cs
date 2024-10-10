using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Template.Trunk.Shared.Constants.OpenAPI;

namespace Template.Trunk.OpenAPI.Controllers.Version_1.User;

[ApiExplorerSettings(GroupName = ApiSettingsConst.Tag.User)]
public class BaseUserController : BaseApiController
{
}
