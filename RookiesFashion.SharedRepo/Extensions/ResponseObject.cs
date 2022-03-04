using System.Net;
using System.Text;
using RookiesFashion.SharedRepo.Constants;

namespace RookiesFashion.SharedRepo.Extensions;
public class ResponseObject
{
    public string? Message { get; set; }
    public object? Data { get; set; }
    public int Code { get; set; }

}