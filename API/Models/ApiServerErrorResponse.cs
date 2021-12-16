using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ApiServerErrorResponse : ApiErrorResponse
    {
        public string Details { get; set; }
        public ApiServerErrorResponse(int statusCode, string message = null,string details =null) : base(statusCode, message)
        {
            Details = details;
        }
    }
}