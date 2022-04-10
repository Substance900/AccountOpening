using Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
   public class AccountStageResponse: BaseResponse
    {
        public AccountOpeningStatus accountOpeningStatus { get; set; }
    }
}
