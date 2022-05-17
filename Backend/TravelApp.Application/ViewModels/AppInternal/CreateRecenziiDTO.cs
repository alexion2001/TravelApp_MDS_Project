using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Application.ViewModels.AppInternal
{
    public class CreateRecenziiDTO
    {
        public Guid Id { get; set; }
        public string Oras { get; set; }
        public string Mesaj { get; set; }
    }
}
