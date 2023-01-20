namespace PlacementPortal.Application.Common
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset DateTimeOffsetNow => DateTimeOffset.Now;
    }
}
