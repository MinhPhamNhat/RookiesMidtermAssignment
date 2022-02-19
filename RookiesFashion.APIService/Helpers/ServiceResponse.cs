using System.Net;
using System.Text;
using RookiesFashion.APIService.Constants;

namespace RookiesFashion.APIService.Helpers
{
    public class ServiceResponse
    {
        public ServiceResponseStatus Code { get; set; }
        public string Message { get; set; }
        public Exception RespException { get; set; }
        public object Data { get; set; }
        
    }
}