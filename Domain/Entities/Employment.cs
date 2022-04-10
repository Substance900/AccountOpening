using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class Employment: AuditableEntity
    {
        public string EmploymentStatus { get; set; }
        public string Occupation { get; set; }
        public string EmployerName { get; set; }

        public string EmployerAddress { get; set; }
        public string EmploymentDate { get; set; }
        public string Bvn { get; set; }
    }
}
