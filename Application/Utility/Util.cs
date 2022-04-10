using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Application.Request;
using Application.Response;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.Utility
{
    public class Util
    {
        private const string NUM_REGEX = @"(?=.*?[0-9])";
        private const string UPPER_REGEX = @"(?=.*?[A-Z])";
        private const string LOWER_REGEX = @"(?=.*?[a-z])";
        private const string SPECIAL_CHAR_REGEX = @"(?=.*?[#?!@$%^&*-\.])";
        private const string MIN_LENGTH_REGEX = @".{x,}";
        static JsonSerializerSettings settings = new JsonSerializerSettings { MissingMemberHandling = MissingMemberHandling.Ignore };
        public static bool IsNumeric(object obj)
        {
            switch (System.Type.GetTypeCode(obj.GetType()))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsValidPassword(string password, string minLength, int hasNum, int hasUpp, int hasLow, int hasSpc)
        {
            var regexString = @"^UppLowNumSpcMinLen$";
            regexString = hasUpp > 0 ? regexString.Replace("Upp", UPPER_REGEX) : regexString.Replace("Upp", "");
            regexString = hasLow > 0 ? regexString.Replace("Low", LOWER_REGEX) : regexString.Replace("Low", "");
            regexString = hasNum > 0 ? regexString.Replace("Num", NUM_REGEX) : regexString.Replace("Num", "");
            regexString = hasSpc > 0 ? regexString.Replace("Spc", SPECIAL_CHAR_REGEX) : regexString.Replace("Spc", "");
            regexString = regexString.Replace("MinLen", MIN_LENGTH_REGEX.Replace("x", minLength));
            var rule = new Regex(regexString);
            return rule.IsMatch(password);
        }

        public static string GetPasswordErrorMessage(string minLength, int hasNum, int hasUpp, int hasLow, int hasSpc)
        {
            var list = new List<int> { hasUpp, hasLow, hasNum, hasSpc };
            var truthyNum = GetTruthyNumber(list);
            var mustContain = truthyNum > 0 ? " must contain at least " : "";
            var hasUppStr = hasUpp > 0 ? "1 uppercase letter, " : "";
            var hasLowStr = hasLow > 0 ? "1 lowercase letter, " : "";
            var hasNumStr = hasNum > 0 ? "1 number, " : "";
            var hasSpcStr = hasSpc > 0 ? "1 special character, " : "";
            var and = truthyNum > 0 ? "and" : "";
            return $"Password{mustContain}{hasUppStr}{hasLowStr}{hasNumStr}{hasSpcStr}{and} must be at least {minLength} characters.";
        }

        public static int GetTruthyNumber(List<int> conditions)
        {
            var num = 0;
            foreach (var condition in conditions)
            {
                if (condition > 0) num += 1;
            }
            return num;
        }

        public static string GetRegex(string minLength, int hasNum, int hasUpp, int hasLow, int hasSpc)
        {
            var regexString = @"^UppLowNumSpcMinLen$";
            regexString = hasUpp > 0 ? regexString.Replace("Upp", UPPER_REGEX) : regexString.Replace("Upp", "");
            regexString = hasLow > 0 ? regexString.Replace("Low", LOWER_REGEX) : regexString.Replace("Low", "");
            regexString = hasNum > 0 ? regexString.Replace("Num", NUM_REGEX) : regexString.Replace("Num", "");
            regexString = hasSpc > 0 ? regexString.Replace("Spc", SPECIAL_CHAR_REGEX) : regexString.Replace("Spc", "");
            regexString = regexString.Replace("MinLen", MIN_LENGTH_REGEX.Replace("x", minLength));
            return regexString;
        }

        

        public static bool IsBase64String(string input)
        {
            Span<byte> buffer = new Span<byte>(new byte[input.Length]);
            return Convert.TryFromBase64String(input, buffer, out int bytesParsed);
        }

        private static string Decryptor(string encryptedData, string secretKey)
        {
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            byte[] vectorKeyBytes = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            var decryptor = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 256,
                BlockSize = 128,
                IV = vectorKeyBytes,
                Key = secretKeyBytes,
            };

            var encryptedTextByte = Convert.FromBase64String(encryptedData);
            var DecryptedInBytes = decryptor.CreateDecryptor().TransformFinalBlock(encryptedTextByte, 0, encryptedTextByte.Length);
            return Encoding.UTF8.GetString(DecryptedInBytes);
        }
       
        public static string Encryptor(string request, string secretKey)
        {
            var secretKeyBytes = Encoding.UTF8.GetBytes(secretKey);

            byte[] vectorKeyBytes = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


            var encryptor = new RijndaelManaged
            {
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7,
                KeySize = 256,
                BlockSize = 128,
                IV = vectorKeyBytes,
                Key = secretKeyBytes
            };

            var plainBytes = Encoding.UTF8.GetBytes(request);
            var EncryptedInByte = encryptor.CreateEncryptor().TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            return Convert.ToBase64String(EncryptedInByte);
        }


        //    public static void Main()
        //    {
        //        byte[] encData;
        //        string dcrptData;
        //        string str = "www.includehelp.com";
        //        RijndaelManaged enc = new RijndaelManaged();

        //        enc.GenerateKey();
        //        enc.GenerateIV();

        //        Console.WriteLine("Original String: ", str);

        //        encData = EncryptData(str, enc.Key, enc.IV);

        //        Console.WriteLine("Encrypted bytes: ");
        //        for (int i = 0; i < encData.Length; i++)
        //            Console.Write(encData[i]);
        //        dcrptData = DecryptData(encData, enc.Key, enc.IV);

        //        Console.WriteLine("\nDecrypted string: " + dcrptData);
        //    }

        //}
        private static T DeserializeFromJson<T>(string input)
        {

            return JsonConvert.DeserializeObject<T>(input, settings);
        }

        public static string SerializeAsJson<T>(T item)
        {
            return JsonConvert.SerializeObject(item);
        }

        public static T DecryptRequest<T>(string requestData, string secretKey)
        {
            var decryptedRequest = Decryptor(requestData, secretKey);
            var deserializedRequest = DeserializeFromJson<T>(decryptedRequest);

            return deserializedRequest;
        }

        public static string EncryRequest<T>(T item, string encryptionKey)
        {
          var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var serilizer =JsonConvert.SerializeObject(item, settings);

            return Encryptor(serilizer,encryptionKey);
        }

      
        public static JsonSerializerOptions CreateJsonOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            options.Converters.Add(new JsonStringEnumConverter());
            return options;
        }
    }
}
