using Application.Common.AppConfig;
using Application.Contracts.Infrastructure;
using Application.Utility;
using Infrastructure.Services;
using Infrastructure.Services.FakeService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
   public static class InfrastructureServiceRegistration
    {
        private static AccountOpeningConfig _accountOpeningServiceConfig;
        private static FiServiceConfig _fiServiceConfig;
        private static EmailConfig _emailConfig;
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
            services.Configure<AccountOpeningConfig>(opt => configuration.GetSection("AccountOpeningConfig").Bind(opt));
            services.Configure<FiServiceConfig>(configuration.GetSection("FiServiceConfig"));
            services.Configure<EmailConfig>(configuration.GetSection("EmailConfig"));

            services.AddTransient<ApplicationUtility>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IBvnService, FakeBvnService>();
           
         

            _accountOpeningServiceConfig = configuration.GetSection(nameof(AccountOpeningConfig)).Get<AccountOpeningConfig>();
            _fiServiceConfig = configuration.GetSection(nameof(FiServiceConfig)).Get<FiServiceConfig>();
            _emailConfig = configuration.GetSection(nameof(EmailConfig)).Get<EmailConfig>();
            services.AddHttpClient(_emailConfig.EmailClientName, c => c.BaseAddress = new Uri(_emailConfig.BaseUrl));
            services.AddHttpClient(_accountOpeningServiceConfig.AccountOpeningClientName, opt =>
            {
                opt.BaseAddress = new Uri(_accountOpeningServiceConfig.AccountOpeningBaseUrl);
                opt.Timeout = TimeSpan.FromMinutes(5);
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.MaxConnectionsPerServer = 10;
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                return clientHandler;
            });
            services.AddHttpClient(_fiServiceConfig.FiClientName, opt =>
            {
                opt.BaseAddress = new Uri(_fiServiceConfig.FiBaseUrl);
                opt.Timeout = TimeSpan.FromMinutes(5);
            }).ConfigurePrimaryHttpMessageHandler(() =>
            {
                var clientHandler = new HttpClientHandler();
                clientHandler.MaxConnectionsPerServer = 10;
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;
                return clientHandler;
            });
           
            
            
            return services;
        }
    }
}
