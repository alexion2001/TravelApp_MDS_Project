using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.Common.Configurations
{
    public class SecretSettings
    {
        public const string NAME = "Hashing";

        public string HashingKey { get; set; }

    }
}
