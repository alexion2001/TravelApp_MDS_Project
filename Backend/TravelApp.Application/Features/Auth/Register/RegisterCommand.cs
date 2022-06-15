using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Common.Exceptions;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Features.Auth.Register
{
    public class RegisterCommand : IRequest<bool>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumberCountryPrefix { get; set; }
    }
    internal class RegisterCommandHandler : IRequestHandler<RegisterCommand, bool>
    {
        private readonly IUserManager _userManager;
        private readonly IEmailManager _emailManager;
        private readonly ITokenManager _tokenManager;
        public RegisterCommandHandler(IUserManager userManager, IEmailManager emailManager, ITokenManager tokenManager)
        {
            _userManager = userManager;
            _emailManager = emailManager;
            _tokenManager = tokenManager;
        }
        public async Task<bool> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            bool ok = false;
            var userProps = await _userManager.GetUserSelectedProperties(request.Email, user => new { user.Id, user.Email });
            if (userProps != null)
            {

                string message = $"Username={ request.Email} already registered";
                throw new UserAlreadyRegisteredException(nameof(IdentityUser), message);
            }
            else
            {
                var result = await _userManager.Register(request);
                var tokenFilterAndCreate = await _tokenManager.CreateConfirmationToken(result.Id, ConfirmationTokenType.EMAIL_CONFIRMATION);
                await _emailManager.SendEmailConfirmation(result, tokenFilterAndCreate);
                ok = true;

            }
            return ok;
        }
    }
}
