namespace Template.Trunk.Server.Application.Common.Domain;

public class ApiActionResult<T>
{
    public T Data { get; set; } = default!;
    public List<ErrorMessage> Errors { get; set; } = default!;
    public bool IsSuccess { get => Errors != null && !Errors.Any(); }
}
