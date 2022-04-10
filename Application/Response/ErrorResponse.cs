using System.Collections.Generic;
using System.Text.Json;

namespace Application.Response
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public string Description { get; set; }
        public IList<string> Details { get; set; }

        public ErrorResponse()
        {
            Details = new List<string>();
        }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}