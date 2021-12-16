using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;

        public BuggyController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet("notfound")]
        public ActionResult Notfound()
        {
            return NotFound(new ApiErrorResponse(404));
        }

        [HttpGet("wrongparam/{code}")]
        public ActionResult WrongParam(int code)
        {
            return Ok();
        }

          [HttpGet("servererror")]
        public ActionResult ServerError()
        {
            var prod = _context.Products.Find(-1);
            var fail = prod.ToString();
            return Ok(new ApiErrorResponse(404));
        }

    }
}