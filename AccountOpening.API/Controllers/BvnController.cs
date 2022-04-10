using Application.Request;
using Application.Response;
using Application.Utility;
using AutoMapper;
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
    public class BvnController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
       // private readonly ApplicationUtility _applicationUtility;

        public BvnController(IMediator mediator, IMapper mapper, ApplicationUtility applicationUtility)
        {
            _mapper = mapper;
            _mediator = mediator;
          //  _applicationUtility = applicationUtility;
        }

        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("VerifyBvn")]
        //public async Task<ActionResult<BvnVerificationResponse>> VerifyBvnAsync([FromBody] BaseEncryptedRequestDTO encryptedRequestData)
        //{
        //    var request = _applicationUtility.GetDecryptedData<BvnVerificationRequest>(encryptedRequestData);
        //    if (!request.Item2.IsSuccessful)
        //    {
        //        return ResolveActionResult(request.Item2);
        //    }
        //     var resp = await _mediator.Send(request.Item1);
        //    return ResolveActionResult(resp);
                     
        //}
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [HttpPost("TestBvn")]
        public async Task<ActionResult<BaseResponse>> TestBvnAsync([FromBody] BvnVerificationRequest request)
        {

            var resp = await _mediator.Send(request);
            
            return ResolveActionResult(resp);

        }

        [HttpPost("OtpRequest")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> OtpRequestAsync([FromBody] GenerateOtpRequest cmd)
        {

            var response = await _mediator.Send(cmd);
            return ResolveActionResult(response);
        }
        [HttpPost("ValidateOtp")]
        [ProducesResponseType(typeof(BaseResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<BaseResponse>> ValidateOtpAsync([FromBody] OtpValidationRequest cmd)
        {

            var response = await _mediator.Send(cmd);
            return ResolveActionResult(response);
        }

    }
}
