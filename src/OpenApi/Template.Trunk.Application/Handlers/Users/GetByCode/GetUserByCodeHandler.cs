using Template.Trunk.Server.Application.Common.Domain;

namespace Template.Trunk.Server.Application.Handlers.Users.GetByCode;

public interface IGetUserByCodeHandler
{
    Task<ApiActionResult<GetUserByCodeResponse>> DoActionAsync(string userCode);
}

public class GetUserByCodeHandler : IGetUserByCodeHandler
{
    public Task<ApiActionResult<GetUserByCodeResponse>> DoActionAsync(string userCode)
    {
        throw new NotImplementedException();
    }
}
