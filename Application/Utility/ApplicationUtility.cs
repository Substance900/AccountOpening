using Application.Common.AppConfig;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OtpNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utility
{
    public class ApplicationUtility
    {
        private readonly AppSettings _utilitySettings;
        private readonly ILogger<ApplicationUtility> _logger;

        public ApplicationUtility(IOptions<AppSettings> utilitySettingsOptions, ILogger<ApplicationUtility> logger)
        {
            _utilitySettings = utilitySettingsOptions.Value;
            _logger = logger;
        }
        public Tuple<T, BaseResponse> GetDecryptedData<T>(BaseEncryptedRequestDTO request)
        {
            BaseResponse baseResponse;
            if (string.IsNullOrEmpty(request.EncryptedData))
            {

                baseResponse = new BaseResponse
                {
                    Status = StatusCodes.Status400BadRequest,
                    IsSuccessful = false,
                    Error = new ErrorResponse
                    {
                        Description = "Invalid encryption"
                    }
                };
                return new Tuple<T, BaseResponse>(default, baseResponse);
            }
            if (!Util.IsBase64String(request.EncryptedData))
            {
                baseResponse = new BaseResponse
                {
                    Status = StatusCodes.Status400BadRequest,
                    IsSuccessful = false,
                    Error = new ErrorResponse
                    {
                        Description = "Invalid encryption"
                    }
                };
                return new Tuple<T, BaseResponse>(default, baseResponse);
            }

            try
            {
                var deserializedData = Util.DecryptRequest<T>(request.EncryptedData, _utilitySettings.EncryptionKey);
                if (deserializedData != null)
                {
                    baseResponse = new BaseResponse { IsSuccessful = true, Status = StatusCodes.Status200OK };
                    return new Tuple<T, BaseResponse>(deserializedData, baseResponse);
                }
                baseResponse = new BaseResponse
                {
                    Status = StatusCodes.Status400BadRequest,
                    IsSuccessful = false,
                    Error = new ErrorResponse
                    {
                        Description = "Invalid encryption"
                    }
                };
                return new Tuple<T, BaseResponse>(default, baseResponse);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Decryption error");
                baseResponse = new BaseResponse
                {
                    Status = StatusCodes.Status400BadRequest,
                    IsSuccessful = false,
                    Error = new ErrorResponse
                    {
                        Description = "Invalid encryption"
                    }
                };
                return new Tuple<T, BaseResponse>(default, baseResponse);
            }
        }

        public string GetEncryptData<T>(T request)
        {
            if (request == null) return null;
            try
            {
                var serializedData = Util.EncryRequest(request, _utilitySettings.EncryptionKey);
                if (serializedData != null) return serializedData;


                return null;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Decryption error");

                return null;
            }
        }

        public static string CleanPhoneNumber(string phoneNumber)
        {
            switch (string.IsNullOrEmpty(phoneNumber))
            {
                case false:
                    {
                        phoneNumber = phoneNumber.Replace(" ", string.Empty).Replace("+", string.Empty).Replace(")", "").Replace("(", "");

                        if (phoneNumber.StartsWith("0"))
                        {
                            phoneNumber = $"234{phoneNumber.Substring(1)}";
                        }

                        if (!phoneNumber.StartsWith("234"))
                        {
                            phoneNumber = $"234{phoneNumber}";
                        }

                        return phoneNumber;
                    }
                default:
                    return default;
            }
        }

        private static string GenerateRandomNumber(int no)
        {
            var rand = new Random();
            var s = string.Empty;
            for (var i = 0; i < no; i++)
            {
                s = string.Concat(s, rand.Next(10).ToString());
            }
            return s;
        }
        public  Task<string> GenerateOtp()
        {
            var key = KeyGeneration.GenerateRandomKey(20);

            var base32String = Base32Encoding.ToString(key);
            var base32Bytes = Base32Encoding.ToBytes(base32String);
            var otp = new Totp(base32Bytes);
            var totpCode = otp.ComputeTotp();
            return Task.FromResult(totpCode);
        }
    }
}
