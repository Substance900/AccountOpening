using Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Request
{
   public class ChoiceOfAccountRequest:IRequest<BaseResponse>
    {
        public string AccountType { get; set; }

        public bool HasUtilityBill { get; set; }

        public bool HasValidId { get; set; }

        public string Bvn { get; set; }
    }
}
