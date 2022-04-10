using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
  public  class BvnVerificationRequest : IRequest<BvnVerificationResponse>
    {
        public string Bvn { get; set; }
        public string DateOfBirth { get; set; }
    }
}
