using Application.Contracts.Persistence;
using Application.Enum;
using Application.Request;
using Application.Response;
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
    public class AccountStageHandler : IRequestHandler<AccountStageRequest, AccountStageResponse>
    {
        private readonly IAccountOpeningDbContext _accountOpeningDbContext;

        public AccountStageHandler(IAccountOpeningDbContext accountOpeningDbContext)
        {
            _accountOpeningDbContext = accountOpeningDbContext;
        }
        public async Task<AccountStageResponse> Handle(AccountStageRequest request, CancellationToken cancellationToken)
        {
         var check= await  _accountOpeningDbContext.AccountOpeningStages.FirstAsync(x => x.Bvn.Equals(request.Bvn));

            if (!string.IsNullOrEmpty( check.Bvn))
            {
                return new AccountStageResponse {IsSuccessful=true, Message= ((AccountOpeningStatus)check.Stage).ToString(), Status = StatusCodes.Status200OK , accountOpeningStatus = (AccountOpeningStatus)check.Stage };
            }
            return new AccountStageResponse { Error = new ErrorResponse { Description = "Could not get customer accountstage" }, IsSuccessful = false, Message = "Could not get customer accountstage", Status = StatusCodes.Status400BadRequest };
           
        }
    }
}
