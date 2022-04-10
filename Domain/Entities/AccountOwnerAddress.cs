using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class AccountOwnerAddress: AuditableEntity
    {
        public string HouseNo { get; set; }
        public string StreetNo { get; set; }
        public string City { get; set; }

        public string State { get; set; }
        public string Lgt { get; set; }
        public string Bvn { get; set; }
    }
}
