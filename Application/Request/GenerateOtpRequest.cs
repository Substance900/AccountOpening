using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
   public class GenerateOtpRequest : IRequest<BaseResponse>
    {
        public string CustomerEmail { get; set; }
    }
}
