using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.ViewModels.External.Auth
{
    public class TokenWrapper
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
