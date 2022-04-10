using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class ChoiceOfAccount:AuditableEntity
    {
        public string AccountType { get; set; }

        public bool HasUtilityBill { get; set; }

        public bool HasValidId { get; set; }

        public string Bvn { get; set; }

    }
}
