namespace Template.Trunk.Server.Application.Handlers.Users.GenerateToken;

public interface IGenerateUserTokenHandler
{
    Task<GenerateUserTokenResponse> DoActionAsync(GenerateUserTokenRequest request);
}

public class GenerateUserTokenHandler : IGenerateUserTokenHandler
{
    public Task<GenerateUserTokenResponse> DoActionAsync(GenerateUserTokenRequest request)
    {
        throw new NotImplementedException();
    }
}
