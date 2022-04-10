using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class AccountOpeningStage:AuditableEntity
    {
        public string Bvn { get; set; }

        public int Stage { get; set; }

    }
}
