using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.Common.Exceptions
{
    public class SessionExpiredException : Exception
    {
        public SessionExpiredException(string errMessage) : base(errMessage)
        {

        }
    }
}
