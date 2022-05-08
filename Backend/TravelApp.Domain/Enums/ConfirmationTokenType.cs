using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Domain.Enums
{
    public enum ConfirmationTokenType : byte
    {
        EMAIL_CONFIRMATION = 1,
        PHONE_CONFIRMATION = 2,
        RESET_PASSWORD = 3,
        TWO_FACTOR_CODE = 4
    }
}
