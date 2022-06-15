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

namespace TravelApp.Application.Features.Auth.PasswordRecovery
{
    public class PasswordRecoveryCommand : IRequest<bool>
    {
        public string Email { get; set; }
    }
    internal class PasswordRecoveryCommandHandler : IRequestHandler<PasswordRecoveryCommand, bool>
    {
        private readonly IEmailManager _emailManager;
        private readonly IUserManager _userManager;
        private readonly ITokenManager _tokenManager;
        public PasswordRecoveryCommandHandler(IEmailManager emailManager, IUserManager userManager, ITokenManager tokenManager)
        {
            _emailManager = emailManager; _userManager = userManager;
            _tokenManager = tokenManager;
        }

        public async Task<bool> Handle(PasswordRecoveryCommand request, CancellationToken cancellationToken)
        {

            var user = await _userManager.GetUserByEmail(request.Email);

            //var token = await _tokenManager.MailTokenConfig(user.Id,ConfirmationTokenType.RESET_PASSWORD);

            //trebuie sa trimit mail catre emailul specificat cu un link care duce catre un alt endpoint unde 
            //este specificata noua parola si verificata apoi se face update in baza de date.
            if (user != null)
            {
                if (user.EmailConfirmed == true)
                {
                    var token = await _tokenManager.CreateConfirmationToken(user.Id, ConfirmationTokenType.RESET_PASSWORD);
                    var result = await _emailManager.SendPasswordRecoveryEmail(user, token);
                    if (result == true)
                    {
                        return true;
                    }
                    else
                    {
                        throw new MailConfirmationFailedToSendException("email could not be sent ");
                    }
                }
                else
                {
                    throw new CouldNotConfirmEmailException("please confirm your email first");
                }

            }
            else
            {
                throw new UserNotFoundException("User not found. Please register");
            }



        }
    }
}
