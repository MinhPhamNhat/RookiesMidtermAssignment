using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookiesFashion.APIService.Constants;
using RookiesFashion.APIService.Ex;
using RookiesFashion.APIService.Extension;

namespace RookiesFashion.APIService.Helpers
{
    public class MyApiHelper
    {

        public HttpContext _context;
        public MyApiHelper(HttpContext context)
        {
            _context = context;
        }
        public JsonResult ResponseMessage(HttpStatusCode statusCode, object resultObj)
        {
            _context.Response.StatusCode = (int)statusCode;
            return new JsonResult(resultObj);
        }

        public JsonResult GetRequestServiceResult(ServiceResponse serResp)
        {
            switch (serResp.Code)
            {
                case ServiceResponseConstants.SUCCESS:
                    return ResponseMessage(HttpStatusCode.OK, new { Message = serResp.Message, Data = serResp.Data });
                case ServiceResponseConstants.ERROR:
                    return ResponseMessage(HttpStatusCode.InternalServerError, new { Message = serResp.Message, Data = serResp.Data });
                case ServiceResponseConstants.OBJECT_NOT_FOUND:
                    return ResponseMessage(HttpStatusCode.NotFound, new { Message = serResp.Message, Data = serResp.Data });
                case ServiceResponseConstants.DATA_CREATED:
                    return ResponseMessage(HttpStatusCode.Created, new { Message = serResp.Message, Data = serResp.Data });
                default:
                    return ResponseMessage(HttpStatusCode.BadRequest, new { Message = "Bad request" });
            }
        }

        public JsonResult ValidationResponseMessage(string field, object value, string message) => ResponseMessage(HttpStatusCode.BadRequest, new ValidationResultModel(new ValidationError(field, value, message)));
    }
}