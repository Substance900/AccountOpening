using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Response
{
    public class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public ErrorResponse Error { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
