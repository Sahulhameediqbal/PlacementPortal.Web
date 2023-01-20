namespace PlacementPortal.Model.Common
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public object? Response { get; set; } = null!;
        public object Errors { get; set; } = null!;
    }

    public class ErrorMessage
    {
        public string Message { get; set; } = null!;
    }
}
