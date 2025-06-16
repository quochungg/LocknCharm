namespace LocknCharm.Application.Common
{
    public class APIResponse
    {
        public bool IsSuccess { get; set; } = true;
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
        public object? Data { get; set; }

        public static APIResponse Fail(string message, List<string>? errors = null, int statusCode = 500)
        {
            return new APIResponse
            {
                IsSuccess = false,
                StatusCode = statusCode,
                Message = message,
                Errors = errors
            };
        }

        public static APIResponse Success(int statusCode, string message, object? data = null)
        {
            return new APIResponse
            {
                StatusCode = statusCode,
                IsSuccess = true,
                Message = message,
                Data = data
            };
        }
    }

}
