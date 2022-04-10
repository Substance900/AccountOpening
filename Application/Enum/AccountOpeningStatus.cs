using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Enum
{
    public enum AccountOpeningStatus
    {
        BvnVerification = 1,
        AccountReason,
        AccountOwner,
        FATCA,
        AddressOwnerAddress,
        Employment,
        NextOfKin,
        DocumentUpload,
        DocumentUploadCompulsory,
        Summary,
        Completed
    }
}
