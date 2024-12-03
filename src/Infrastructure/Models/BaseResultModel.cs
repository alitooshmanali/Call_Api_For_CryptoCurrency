using System.Net;

namespace Infrastructure.Models
{
    public class BaseResultModel
    {
        public string Body { get; set; }

        public string ResponseJson { get; set; }

        public HttpStatusCode ResponseCode { get; set; }

        public string ActionMethod { get; set; }

        public string ErrorMessage { get; set; }

        public bool IsSuccess { get; set; }
    }
}
