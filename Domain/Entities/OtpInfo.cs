using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
  public class OtpInfo: AuditableEntity
    {
        public string CustomerId { get; set; }
        public string OtpCode { get; set; }
        public int OptStatus { get; set; }
        public int TransactionType { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
