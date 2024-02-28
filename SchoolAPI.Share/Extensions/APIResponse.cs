using System.Net;

namespace SchoolAPI.Shared.Extensions
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string>? Errors { get; set; }
        public object? Result { get; set; }
    }
}
