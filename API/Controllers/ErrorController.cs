﻿using API.Errors;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseApiController
    {
        [HttpGet]
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
