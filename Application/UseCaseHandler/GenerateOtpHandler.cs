using Application.Contracts.Infrastructure;
using Application.Contracts.Persistence;
using Application.Enum;
using Application.Models;
using Application.Request;
using Application.Response;
using Application.Utility;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class GenerateOtpHandler : IRequestHandler<GenerateOtpRequest, BaseResponse>
    {
        private readonly IEmailService _emailService;
        private readonly ApplicationUtility _applicationUtility;
        private readonly IAccountOpeningDbContext _accountOpeningDbContext;
        private readonly ILogger<EmailResponse> _logger;

        public GenerateOtpHandler( IEmailService emailService, ApplicationUtility applicationUtility, IAccountOpeningDbContext accountOpeningDbContext, ILogger<EmailResponse> logger)
        {
            _emailService = emailService;
            _applicationUtility = applicationUtility;
            _accountOpeningDbContext = accountOpeningDbContext;
            _logger = logger;
        }
        public async Task<BaseResponse> Handle(GenerateOtpRequest request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.CustomerEmail))
            {
                var generateOTP = await _applicationUtility.GenerateOtp();

                var obj = new OtpInfo { ExpiryDate = DateTime.Now.AddMinutes(5), OtpCode = generateOTP, OptStatus = (int)OtpStatus.Initiated, CustomerId = request.CustomerEmail };

                var msg = $"Dear Customer, your otp for validation is {generateOTP}";
                var email = new Email { Message = msg, Recipient = request.CustomerEmail, Subject = "OTP Request" };
                int rId;

                try
                {
                    await _accountOpeningDbContext.OtpInfos.AddAsync(obj);
                    rId = await _accountOpeningDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Could not generate otp at this time" +
                            $"{Environment.NewLine}===========================Error Details===================================" +
                            $"{Environment.NewLine}{ex.Message}", ex);
                    return new BaseResponse { Status= StatusCodes.Status400BadRequest, IsSuccessful = false, Error=new ErrorResponse { Description=ex.Message} };

                }

                if (rId > 0)
                {


                    _logger.LogInformation($"Email request" +
                          $"{Environment.NewLine}{JsonSerializer.Serialize(email)}");
                    var emailResponse = await _emailService.SendEmail(email);
                    return emailResponse;

                }


            }
            return new BaseResponse { };
        }
    }
}
