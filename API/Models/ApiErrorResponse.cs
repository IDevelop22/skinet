using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ApiErrorResponse
    {
        public ApiErrorResponse(int statusCode, string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetStatusCodeErrorMessage(statusCode);
        }

        private string GetStatusCodeErrorMessage(int statusCode)
        {
            return statusCode switch
            {
                400 => "Bad Request",
                404 => "SOmething Not Found",
                500 => "A very big problem with the server",
                _ => "Something is not right"
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        
    }
}