using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Domain.Entities;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IEmailManager
    {
        Task SendEmailConfirmation(IdentityUser user, IdentityUserTokenConfirmation token);
        Task<bool> IsEmailConfirmed(string userIntroducedToken, IdentityUserTokenConfirmation TokenFromDb, IdentityUser user);
        Task<bool> SendPasswordRecoveryEmail(IdentityUser user, IdentityUserTokenConfirmation token);

    }
}
