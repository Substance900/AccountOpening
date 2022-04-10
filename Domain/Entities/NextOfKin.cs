using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public  class NextOfKin: AuditableEntity
    {
        public string NoKSurname { get; set; }
        public string NokFirstname { get; set; }

        public string NokOthernames { get; set; }
        public string NokDateOfBirth { get; set; }

        public string NokRelationship { get; set; }

        public string Bvn { get; set; }
    }
}
