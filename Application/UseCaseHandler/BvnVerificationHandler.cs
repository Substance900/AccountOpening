using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Enum;
using Application.Models;
using Application.Request;
using Application.Response;
using Application.Utility;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCaseHandler
{
    public class BvnVerificationHandler : IRequestHandler<BvnVerificationRequest, BvnVerificationResponse>
    {
        private readonly IBvnService _bvnService;
       
        public BvnVerificationHandler(IBvnService bvnService)
        {
            _bvnService = bvnService;
           
            

        }
        public async Task<BvnVerificationResponse> Handle(BvnVerificationRequest request, CancellationToken cancellationToken)
        {

            var response = _bvnService.VerifyBvn(request);

           

            return await response;

        }
        
    }
}
