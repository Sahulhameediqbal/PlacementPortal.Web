namespace PlacementPortal.Application.Common
{
    public interface IDateTimeProvider
    {
        DateTimeOffset DateTimeOffsetNow { get; }
    }
}
