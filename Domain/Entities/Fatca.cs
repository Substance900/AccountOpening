using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Fatca: AuditableEntity
    {
        public bool USResident { get; set; }
        public bool USCitizen { get; set; }

        public bool USGreenCard { get; set; }
        public bool OECDResident { get; set; }
        public bool OECDControlling { get; set; }
        public string Bvn { get; set; }
    }
}
