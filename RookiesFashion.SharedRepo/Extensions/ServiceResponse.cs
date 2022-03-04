using System.Net;
using System.Text;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.SharedRepo.Extensions;
public class ServiceResponse
{
    public ServiceResponseConstants Code { get; set; }
    public string? Message { get; set; }
    public Exception? RespException { get; set; }
    public object? Data { get; set; }

}