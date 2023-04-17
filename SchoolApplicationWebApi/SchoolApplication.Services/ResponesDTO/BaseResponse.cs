using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Services
{
    public class BaseResponse
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public object Data { get; set; }
        public string Errors { get; set; }
    }
}
