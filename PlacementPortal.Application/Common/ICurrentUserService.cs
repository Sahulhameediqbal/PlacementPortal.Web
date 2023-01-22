namespace PlacementPortal.Application.Common
{
    public interface ICurrentUserService
    {
        Guid UserId { get; }
        string Name { get; }
        string Email { get; }
        string Role { get; }
        Guid CompanyId { get; }
        Guid CollegeId { get; }
    }
}
