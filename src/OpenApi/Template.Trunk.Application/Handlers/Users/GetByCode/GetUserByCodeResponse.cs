namespace Template.Trunk.Server.Application.Handlers.Users.GetByCode;

public record GetUserByCodeResponse
{
    public string Code { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
}
