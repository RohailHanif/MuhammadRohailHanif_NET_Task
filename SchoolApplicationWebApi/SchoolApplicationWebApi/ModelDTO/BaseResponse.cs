using System.Net;

namespace SchoolApplication.ModelDTO
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Data { get; set; }
        public string Errors { get; set; }
    }
}
