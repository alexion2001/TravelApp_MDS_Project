using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.Common.Exceptions
{
    public class IncorrectPasswordException : Exception
    {
        public IncorrectPasswordException(string errMessage) : base(errMessage)
        {

        }
    }
}
