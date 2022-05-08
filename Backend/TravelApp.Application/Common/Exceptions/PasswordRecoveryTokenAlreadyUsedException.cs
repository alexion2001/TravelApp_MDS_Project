using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.Common.Exceptions
{
    public class PasswordRecoveryTokenAlreadyUsedException : Exception
    {
        public PasswordRecoveryTokenAlreadyUsedException(string errMessage) : base(errMessage)
        {

        }
    }
}
