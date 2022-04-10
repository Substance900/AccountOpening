using Application.Request;
using Application.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountOpening.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountOpeningController : BaseController
    {
        private readonly IMediator _mediator;

        public AccountOpeningController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("PostChoiceOfAccount")]
        public async Task<ActionResult<BaseResponse>> PostChoiceOfAccountAsync([FromBody] ChoiceOfAccountRequest request)
        {

            var resp = await _mediator.Send(request);

            return ResolveActionResult(resp);

        }

        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("GetAccountStage")]
        public async Task<ActionResult<BaseResponse>> GetAccountStageAsync([FromBody] AccountStageRequest request)
        {

            var resp = await _mediator.Send(request);

            return ResolveActionResult(resp);

        }
    }
}
