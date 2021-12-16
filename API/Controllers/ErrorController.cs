using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseApiController
    {
        [HttpGet("errors/{code}")]
        public ActionResult Errors(int code)
        {
            return NotFound(new ApiErrorResponse(code));
        }
    }
}