using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
   public class AccountStageRequest: IRequest<AccountStageResponse>
    {
        public string Bvn { get; set; }
    }
}
