namespace Template.Trunk.Server.Application.Handlers.Users.GetByCode;

public interface IGetUserByCodeHandler
{
    Task<GetUserByCodeResponse> DoActionAsync(string userCode);
}

public class GetUserByCodeHandler : IGetUserByCodeHandler
{
    public Task<GetUserByCodeResponse> DoActionAsync(string userCode)
    {
        throw new NotImplementedException();
    }
}
