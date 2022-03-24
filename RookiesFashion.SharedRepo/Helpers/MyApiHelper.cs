using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RookiesFashion.SharedRepo.Constants;
using RookiesFashion.SharedRepo.Extension;
using RookiesFashion.SharedRepo.Extensions;

namespace RookiesFashion.SharedRepo.Helpers
{
    public static class MyApiHelper
    {
        public static JsonResult ResponseMessage(HttpStatusCode statusCode, ResponseObject resultObj, HttpContext context)
        {
            context.Response.StatusCode = (int)statusCode;
            return new JsonResult(resultObj);
        }

        public static JsonResult RequestResultParser(ServiceResponse serResp, HttpContext context)
        {
            ResponseObject responseObject = new ResponseObject
            {
                Message = serResp.Message,
                Data = serResp.Data
            };
            switch (serResp.Code)
            {
                case ServiceResponseConstants.SUCCESS:
                    return ResponseMessage(HttpStatusCode.OK, responseObject, context);
                case ServiceResponseConstants.ERROR:
                    return ResponseMessage(HttpStatusCode.InternalServerError, responseObject, context);
                case ServiceResponseConstants.OBJECT_NOT_FOUND:
                    return ResponseMessage(HttpStatusCode.NotFound, responseObject, context);
                case ServiceResponseConstants.DATA_CREATED:
                    return ResponseMessage(HttpStatusCode.Created, responseObject, context);
                case ServiceResponseConstants.UNAUTHENTICATED:
                    return ResponseMessage(HttpStatusCode.Unauthorized, responseObject, context);
                default:
                    return ResponseMessage(HttpStatusCode.NoContent, new ResponseObject { }, context);
            }
        }

        public static JsonResult ValidationResponseMessage(ValidationResultModel validationResultModel, HttpContext context)
        {
            ResponseObject responseObject = new ResponseObject
            {
                Message = "Validation Failed",
                Data = validationResultModel.Errors
            };
            return ResponseMessage(HttpStatusCode.BadRequest, responseObject, context);
        }

        public static JsonResult ValidationFailedResponseMessage(string field, object value, string message, HttpContext context)
        {
            ValidationResultModel validationResultModel = new ValidationResultModel(new ValidationError(field, value, message));
            return ValidationResponseMessage(validationResultModel, context);
            
        }

        public static async Task<ServiceResponse> ReadApiResponse(HttpResponseMessage respMess, string? method = "Get")
        {
            ResponseObject respObj = new ResponseObject();
            try
            {
                respObj = (ResponseObject)(await respMess.Content.ReadFromJsonAsync<ResponseObject>());
            }
            catch
            {
                respObj.Data = await respMess.Content.ReadAsStringAsync();
            }
            var serResp = new ServiceResponse
            {
                Data = respObj.Data,
                Message = respObj.Message
            };
            switch (respMess.StatusCode)
            {
                case HttpStatusCode.OK:
                    serResp.Code = ServiceResponseConstants.SUCCESS;
                    break;
                case HttpStatusCode.Created:
                    serResp.Code = ServiceResponseConstants.DATA_CREATED;
                    break;

                case HttpStatusCode.NotFound:
                    serResp.Code = ServiceResponseConstants.OBJECT_NOT_FOUND;
                    break;
                case HttpStatusCode.BadRequest:
                    serResp.Code = ServiceResponseConstants.VALIDATION_FAILED;
                    break;

                case HttpStatusCode.InternalServerError:
                    serResp.Code = ServiceResponseConstants.API_ERROR;
                    break;

                case HttpStatusCode.Forbidden:
                    serResp.Code = ServiceResponseConstants.FORBIDDEN;
                    break;

                case HttpStatusCode.Unauthorized:
                    serResp.Code = ServiceResponseConstants.UNAUTHENTICATED;
                    break;
                default:
                    serResp.Code = ServiceResponseConstants.NO_CONTENT;
                    break;
            }

            return serResp;
        }
    }
}