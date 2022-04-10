using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOpening.API.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult ResolveActionResult(BaseResponse response)
        {
            ObjectResult result;
            switch (response.Status)
            {
                case StatusCodes.Status401Unauthorized:
                    result = StatusCode(StatusCodes.Status401Unauthorized, response);
                    break;
                case StatusCodes.Status400BadRequest:
                    result = BadRequest(response);
                    break;
                case StatusCodes.Status409Conflict:
                    result = StatusCode(StatusCodes.Status409Conflict, response);
                    break;
                case StatusCodes.Status200OK:
                    result = Ok(response);
                    break;
                case StatusCodes.Status201Created:
                    result = StatusCode(StatusCodes.Status201Created, response);
                    break;
                case StatusCodes.Status422UnprocessableEntity:
                    result = StatusCode(StatusCodes.Status422UnprocessableEntity, response);
                    break;
                case StatusCodes.Status403Forbidden:
                    result = StatusCode(StatusCodes.Status403Forbidden, response);
                    break;
                case StatusCodes.Status204NoContent:
                    result = StatusCode(StatusCodes.Status204NoContent, response);
                    break;
                default:
                    result = StatusCode(StatusCodes.Status500InternalServerError, response);
                    break;
            }
            return result;
        }
    }
}
