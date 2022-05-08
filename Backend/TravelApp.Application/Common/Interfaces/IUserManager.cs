using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Features.Auth.Login;
using TravelApp.Application.Features.Auth.Register;
using TravelApp.Application.ViewModels.External.Auth;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;

namespace TravelApp.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<T> GetUserSelectedProperties<T>(string uniqueIdentifier, Expression<Func<IdentityUser, T>> selector, CancellationToken cancellationToken = default);
        Task<T> GetUserTokensSelectedProperties<T>(string tokenValue, Expression<Func<IdentityUserTokenConfirmation, T>> selector, CancellationToken cancellationToken = default);
        Task<IdentityUserTokenConfirmation> GetIdentityUserActiveTokenConfirmationByToken(string token, ConfirmationTokenType confirmationTokenType);
        Task<IdentityUser> GetUserById(Guid id);
        Task<IdentityUser> GetUserByEmail(string email);
        Task<IdentityUser> GetUserByIdentityUserTokenConfirmation(string token);

        Task<TokenWrapper> Login(LoginCommand loginCommand);
        Task<IdentityUser> Register(RegisterCommand registerCommand);
        Task<IdentityUserToken> GetUserTokenByRefreshToken(string refreshtoken);
        Task<IdentityUser> updateUser(IdentityUser user);
        Task<IdentityUser> UpdateUserPassword(IdentityUser user, string password);
        Task<bool> saveAsync();
        // Task<IdentityUserTokenConfirmation> GetPasswordRecoveryTokenByUser(IdentityUser user);


    }
}
