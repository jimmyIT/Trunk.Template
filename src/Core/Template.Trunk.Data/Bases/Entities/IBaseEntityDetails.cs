namespace Template.Trunk.Data.Bases.Entities;

public interface IBaseEntityDetails : IBaseEntity
{
    string CreateBy { get; set; }
    DateTime CreatedOn { get; set; }
    string? AmendedBy { get; set; }
    DateTime? AmendedOn { get; set; }
}
