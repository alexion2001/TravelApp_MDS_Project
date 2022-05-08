using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.Common.Exceptions
{
    public class AccountStillLockedException : Exception
    {
        public AccountStillLockedException(string errMessage) : base(errMessage)
        {

        }
    }
}
