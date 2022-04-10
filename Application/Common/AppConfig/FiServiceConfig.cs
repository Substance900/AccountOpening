using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.AppConfig
{
   public class FiServiceConfig
    {
        public string FiClientName { get; set; }
        public string FiBaseUrl { get; set; }
        public string FiAppId { get; set; }
        public string FiAppKey { get; set; }
        public string CountryId { get; set; }
        public string AccountDetailsEndpoint { get; set; }
        public string IntrabankTransferEndpoint { get; set; }
        public string NameEnquiryEndpoint { get; set; }
        public string SuccessResponseCode { get; set; }
        public string ActiveAccountStatus { get; set; }
        public List<string> SchemeCodes { get; set; }
    }
}
