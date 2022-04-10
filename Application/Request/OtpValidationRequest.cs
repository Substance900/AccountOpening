using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
   public class OtpValidationRequest:IRequest<BvnVerificationResponse>
    {
        public string CustomerEmail { get; set; }
        public string OtpToken { get; set; }


    }
}
