using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Request
{
   public class SmsMessageRequest
    {
        
            [JsonPropertyName("to")]
            public List<string> To { get; set; }

            [JsonPropertyName("body")]
            public string Body { get; set; }

            [JsonPropertyName("from")]
            public string From { get; set; }

            [JsonPropertyName("notificationURL")]
            public string NotificationURL { get; set; }

            [JsonPropertyName("clientId")]
            public string ClientId { get; set; }
        
    }
}
