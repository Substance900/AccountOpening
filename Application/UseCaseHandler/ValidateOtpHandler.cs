using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Enum;
using Application.Request;
using Application.Response;
using Application.Utility;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
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
                        otp.LastModifiedDate = DateTime.Now;
                        // to keep track of the Stage
                        var presentStage = new AccountOpeningStage { Bvn = response.Data.Bvn, Stage = (int)AccountOpeningStatus.BvnVerification };

                        await _accountOpeningDbContext.AccountOpeningStages.AddAsync(presentStage);
                        await _accountOpeningDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                        response.Message = msg;
                        response.IsSuccessful = valid;
                        response.Status = StatusCodes.Status200OK;
                        return  response;
                        
                        

                    }
                    else
                    {
                        msg = "Otp has expired";
                        otp.OptStatus = (int)OtpStatus.Expired;
                    }
                   
                    
                    await _accountOpeningDbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                }
            }
           


            return new BvnVerificationResponse { Message = msg, IsSuccessful = valid };
        }
    }
}
