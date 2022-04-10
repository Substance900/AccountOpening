using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Response
{
   public class BvnResponseData
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("bvn")]
        public string Bvn { get; set; }
        [JsonPropertyName("dateOfBirth")]
        public string DateOfBirth { get; set; }
        [JsonPropertyName("phoneNo")]
        public string PhoneNo { get; set; }
        [JsonPropertyName("firstName")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastName")]
        public string LastName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
    }
}
