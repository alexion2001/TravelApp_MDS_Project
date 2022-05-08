using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Exceptions;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Application.ViewModels.External.Email;
using TravelApp.Domain.Entities;
using TravelApp.Infrastructure.Persistence.DbContexts.Travel;

namespace TravelApp.Infrastructure.Services.Managers.Email
{
    public class EmailManager : IEmailManager
    {
        private readonly IEmailSender _emailSender;
        private readonly TravelDbContext _context;
        public EmailManager(IEmailSender emailSender, TravelDbContext context)
        {
            _emailSender = emailSender; _context = context;
        }

        public async Task<bool> IsEmailConfirmed(string userIntroducedToken, IdentityUserTokenConfirmation obj, IdentityUser user)
        {

            if (userIntroducedToken == obj.ConfirmationToken)
            {
                obj.IsUsed = true;
                user.EmailConfirmed = true;
                int updateResult = await _context.SaveChangesAsync();
                return updateResult == 2;

            }
            return false;

        }


        public async Task SendEmailConfirmation(IdentityUser user, IdentityUserTokenConfirmation token)
        {
            try
            {
                //generate random code or link to send to body
                // var message = new MessageUsers(new string[] { user.Email }, "Email Confirmation", $"This is the confirmation code:{token.ConfirmationToken}");
                var message = new MessageUsers(new string[] { user.Email }, "Email Confirmation", $"This is the confirmation code:http://localhost:4200/auth/email-confirmation/{token.ConfirmationToken}");
                await _emailSender.SendEmailAsync(message);


            }
            catch
            {

                throw new MailConfirmationFailedToSendException("Failed to send mail confirmation");
            }

        }
        public async Task<bool> SendPasswordRecoveryEmail(IdentityUser user, IdentityUserTokenConfirmation token)
        {

            try
            {
                var message = new MessageUsers(new string[] { user.Email }, "Password Recovery Link", $"This is the link for password recovery http://localhost:4200/auth/forgot-password/{token.ConfirmationToken}");
                await _emailSender.SendEmailAsync(message);
                return true;
            }
            catch
            {
                return false;

            }

        }
    }
}
