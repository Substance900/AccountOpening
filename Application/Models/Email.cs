using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
   public class Email
    {
        public string AppCode { get; set; }
        public string Recipient { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
