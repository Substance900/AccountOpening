using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Enum;
using Application.Request;
using Application.Response;
using Application.Utility;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCaseHandler
{
    public class ValidateOtpHandler : IRequestHandler<OtpValidationRequest, BvnVerificationResponse>
    {
        private readonly ApplicationUtility _applicationUtility;
        private readonly IAccountOpeningDbContext _accountOpeningDbContext;
        private readonly IBvnService _bvnService;

        public ValidateOtpHandler(ApplicationUtility applicationUtility, IAccountOpeningDbContext accountOpeningDbContext, IBvnService bvnService)
        {
            _bvnService = bvnService;
            _applicationUtility = applicationUtility;
            _accountOpeningDbContext = accountOpeningDbContext;
        }
        public async Task<BvnVerificationResponse> Handle(OtpValidationRequest request, CancellationToken cancellationToken)
        {
            var msg = "Invalid otp";
            var valid = false;
            if (!string.IsNullOrEmpty(request.CustomerEmail)&&!string.IsNullOrEmpty(request.OtpToken))
            {
                var otp = await _accountOpeningDbContext.OtpInfos.FirstOrDefaultAsync(x => x.CustomerId == request.CustomerEmail && x.OtpCode == request.OtpToken && x.OptStatus == (int)OtpStatus.Initiated, cancellationToken: cancellationToken);
                if (otp != null)
                {
                    var check = otp.ExpiryDate < DateTime.Now;
                    if (!check)
                    {
                        valid = true;
                        otp.OptStatus = (int)OtpStatus.Used;
                        msg = "valid otp";
                        var bvnDetails = new BvnDetailRequest { CustomerEmail=request.CustomerEmail};
                        var response = await _bvnService.GetBvnByEmail(bvnDetails);
                        response.Message = msg;
                        response.IsSuccessful = valid;
                        return  response;
                    }
                    else
                    {
                        msg = "Otp has expired";
                        otp.OptStatus = (int)OtpStatus.Expired;
                    }
                    otp.LastModifiedDate = DateTime.Now;
                    
                    await _accountOpeningDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            }
           


            return new BvnVerificationResponse { Message = msg, IsSuccessful = valid };
        }
    }
}
