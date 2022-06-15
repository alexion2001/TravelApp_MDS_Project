using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.ViewModels.External.Email;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IEmailSender
    {
        //void SendEmail(MessageUsers message);
        Task SendEmailAsync(MessageUsers message);
    }
}
