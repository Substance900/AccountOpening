using Application.Request;
using Application.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure
{
    public interface IBvnService
    {
        Task<List<BvnResponseData>> GetBvn();
        Task<BvnVerificationResponse> VerifyBvn(BvnVerificationRequest request);
        Task<BvnVerificationResponse> GetBvnByEmail(BvnDetailRequest request);
        Task<BaseResponse> GenerateOtp(SmsMessageRequest request);
    }

}
