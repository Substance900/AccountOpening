using Application.Contracts.Persistence;
using Application.Request;
using Application.Response;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCaseHandler
{
    public class ChoiceOfAccountHandler : IRequestHandler<ChoiceOfAccountRequest, BaseResponse>
    {
        private readonly IAccountOpeningDbContext _accountOpeningDbContext;
        private readonly ILogger<BaseResponse> _logger;
        public ChoiceOfAccountHandler(IAccountOpeningDbContext accountOpeningDbContext, ILogger<BaseResponse> logger)
        {
            _accountOpeningDbContext = accountOpeningDbContext;
            _logger = logger;
        }
        public async Task<BaseResponse> Handle(ChoiceOfAccountRequest request, CancellationToken cancellationToken)
        {
            int rId;
            try
            {
                var obj = new ChoiceOfAccount
                {
                    AccountType = request.AccountType,
                Bvn = request.Bvn,
                HasUtilityBill = request.HasUtilityBill,
                HasValidId = request.HasValidId
                           };

                await _accountOpeningDbContext.ChoiceOfAccounts.AddAsync(obj);
              rId=  await _accountOpeningDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError($"Could not save choice of account at this time" +
                             $"{Environment.NewLine}===========================Error Details===================================" +
                             $"{Environment.NewLine}{ex.Message}", ex);
                return new BaseResponse { IsSuccessful = false, Message= ex.Message, Error = new ErrorResponse { Description = ex.Message } };
            }

            if (rId > 0)
            {
                return new BaseResponse { IsSuccessful = true, Message = "Choice Of Account Saved", Status = StatusCodes.Status200OK };
            }
            else {
                return new BaseResponse { Error = new ErrorResponse { Description = "Could not save choice of account at this time" },IsSuccessful = false, Message = "Could not save choice of account at this time", Status = StatusCodes.Status400BadRequest };
            }
           
           
        }
    }
}
