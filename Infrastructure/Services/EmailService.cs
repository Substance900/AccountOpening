using Application.Common.AppConfig;
using Application.Contracts.Infrastructure;
using Application.Models;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient client;
        private readonly ILogger<EmailService> _logger;
        private readonly EmailConfig _emailConfig;
       
        public EmailService(IHttpClientFactory clientFactory, ILogger<EmailService> logger, IOptions<EmailConfig> emailConfig)
        {
            _emailConfig = emailConfig.Value;
            client = clientFactory.CreateClient(_emailConfig.EmailClientName);
           
            _logger = logger;
        }
        public async Task<BaseResponse> SendEmail(Email email)
        {
            email.AppCode = _emailConfig.AppCode;
            //email.Recipient = recipient;
            // string url = "/mailer/api/EmailService/SendMail";
         //   string url = "/mailer/api/EmailService/SendSimpleMail";
            var result = new BaseResponse();
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            var json = JsonSerializer.Serialize(email, serializeOptions);
            _logger.LogInformation($"Email Request: {json}{Environment.NewLine}");
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_emailConfig.MailPath, stringContent);
            if (response.IsSuccessStatusCode)
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Success Email Response: {stringResponse}{Environment.NewLine}");
                var rId = JsonSerializer.Deserialize<EmailResponse>(stringResponse);

                result.IsSuccessful = true;
                result.Status = StatusCodes.Status200OK;
                result.Message = "Mail sent";
                return result;

            }
            else
            {
                var stringResponse = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Failed Email Response: {stringResponse}{Environment.NewLine}");
                var rId = JsonSerializer.Deserialize<EmailResponse>(stringResponse);
                result.IsSuccessful = false;
                result.Status = StatusCodes.Status400BadRequest;
                result.Message = "Mail not sent";
               // result.Error = new ErrorResponse { Description = rId.Message };
                return result;

            }

            return result;

        }
    }
}
