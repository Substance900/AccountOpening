using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public  class AccountReason: AuditableEntity
    {
        public string Purpose { get; set; }
        public string SourceOfFund { get; set; }
        public string PreferredBranch { get; set; }

        public string Bvn { get; set; }
    }
}
