using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
   public class AccountOwner: AuditableEntity
    {
        public string Bvn { get; set; }
        public string Title { get; set; }        
        public string MaritalStatus { get; set; }
        public string MotherMaidenName { get; set; }
        public string Nationality { get; set; }
        public string PlaceOfBirth { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public string Gender { get; set; }
        public string MobileNumber { get; set; }

        public string TypeOfAccount { get; set; }

    }
}
