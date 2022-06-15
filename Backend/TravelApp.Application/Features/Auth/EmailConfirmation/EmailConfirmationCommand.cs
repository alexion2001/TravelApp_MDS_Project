using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Common.Exceptions;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Features.Auth.EmailConfirmation
{
    public class EmailConfirmationCommand : IRequest<bool>
    {

        public string ConfirmationToken { get; set; }

    }

    internal class EmailConfirmationCommandHandler : IRequestHandler<EmailConfirmationCommand, bool>
    {
        private readonly IUserManager _userManager;
        private readonly IEmailManager _emailManager;
        private readonly ITokenManager _tokenManager;
        public EmailConfirmationCommandHandler(IUserManager userManager, IEmailManager emailManager, ITokenManager tokenManager)
        {
            _userManager = userManager;
            _emailManager = emailManager;
            _tokenManager = tokenManager;
        }
        public async Task<bool> Handle(EmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            var userTokenProps = await _userManager.GetIdentityUserActiveTokenConfirmationByToken(request.ConfirmationToken, ConfirmationTokenType.EMAIL_CONFIRMATION);

            var userTokenPropsId = userTokenProps.UserId;
            var user = await _userManager.GetUserById(userTokenPropsId);
            var res = await _tokenManager.GetUserActiveConfirmationToken(userTokenPropsId, request.ConfirmationToken, ConfirmationTokenType.EMAIL_CONFIRMATION);
            if (res != null)
            {
                res.IsUsed = true;
                user.EmailConfirmed = true;
                await _userManager.saveAsync();
            }
            if (res == null)
            {
                Console.WriteLine("Resending Email Confirmation");
                var token = await _tokenManager.CreateConfirmationToken(userTokenPropsId, ConfirmationTokenType.EMAIL_CONFIRMATION);
                await _emailManager.SendEmailConfirmation(user, token);

                throw new ResendingEmailConfirmationException("Resending Email Confirmation");
            }

            return true;
        }
    }
}
