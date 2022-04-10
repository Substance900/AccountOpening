using Application.Contracts.Infrastructure;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.FakeService
{
    public class FakeBvnService : IBvnService
    {
       

        public Task<List<BvnResponseData>> GetBvn()
        {
            return Task.FromResult(new
             List<BvnResponseData>
                {
                    new BvnResponseData{Id = 1, Bvn = "1234",DateOfBirth="1990",FirstName="Julie", LastName="Adams",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" },
                    new BvnResponseData{Id = 2, Bvn = "1235",DateOfBirth="1991",FirstName="Jude",LastName="Frank",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" },
                    new BvnResponseData{Id = 3, Bvn = "1236",DateOfBirth="1992",FirstName="Sherif",LastName="Mike",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" },
                    new BvnResponseData{Id = 4, Bvn = "1237",DateOfBirth="1993",FirstName="Father",LastName="Mike",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" },
                    new BvnResponseData{Id = 5, Bvn = "1238",DateOfBirth="1994",FirstName="Julie",LastName="Adams",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" },
                    new BvnResponseData{Id = 6, Bvn = "1239",DateOfBirth="1995",FirstName="Julie",LastName="Adams",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" },
                    new BvnResponseData{Id = 7, Bvn = "1230" ,DateOfBirth="1996",FirstName="Julie",LastName="Adams",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com"},
                    new BvnResponseData{Id = 8, Bvn = "1233" ,DateOfBirth="1997",FirstName="Julie",LastName="Adams",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com"},
                    new BvnResponseData{Id = 9, Bvn = "1232",DateOfBirth="1998",FirstName="Julie",LastName="Adams",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" },
                    new BvnResponseData{Id = 10, Bvn = "1231",DateOfBirth="1999",FirstName="Julie",LastName="Adams",PhoneNo="08160035485", Email="olaoyeoluwafemi@gmail.com" }
                });
        }

        public async Task<BvnVerificationResponse> VerifyBvn(BvnVerificationRequest request)
        {
            var listBvn= await this.GetBvn();
            var result = new BvnVerificationResponse();
            foreach (var item in listBvn)
            {
                if (item.Bvn == request.Bvn && item.DateOfBirth == request.DateOfBirth)
                {
                    return new BvnVerificationResponse { IsSuccessful = true, Status = StatusCodes.Status200OK, Data=item };
                }
            }
            result.Error.Description = "Unable to validate BVN";
            result.IsSuccessful = false;
            result.Status = StatusCodes.Status400BadRequest;
            return  result;
        }
        public async Task<BaseResponse> GenerateOtp(SmsMessageRequest request)
        {

            return new BaseResponse {IsSuccessful=false };
        }

        public async Task<BvnVerificationResponse> GetBvnByEmail(BvnDetailRequest request)
        {
            var listBvn = await this.GetBvn();

            foreach (var item in listBvn)
            {
                if (item.Email == request.CustomerEmail)
                {
                    return new BvnVerificationResponse { IsSuccessful = true, Status = StatusCodes.Status200OK, Data = item };
                }
            }

            return new BvnVerificationResponse { Error = new ErrorResponse { Description = "Unable to validate BVN" }, IsSuccessful = false, Status = StatusCodes.Status404NotFound };

        }
    }
}
