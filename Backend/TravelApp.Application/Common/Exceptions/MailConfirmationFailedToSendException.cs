using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.Common.Exceptions
{
    public class MailConfirmationFailedToSendException : Exception
    {
        public MailConfirmationFailedToSendException(string errMessage) : base(errMessage)
        {

        }
    }
}
