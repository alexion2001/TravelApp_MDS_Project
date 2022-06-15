using MediatR;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TravelApp.Application.Common.Exceptions;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Application.ViewModels.External.Auth;

namespace TravelApp.Application.Features.Auth.RefreshLoginToken
{
    public class RefreshTokenCommand : IRequest<TokenWrapper>
    {
        public string LoginToken { get; set; }
        public string RefreshLoginToken { get; set; }

    }

    internal class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, TokenWrapper>
    {
        private readonly IUserManager _userManager;
        private readonly ITokenManager _tokenManager;


        public RefreshTokenCommandHandler(IUserManager usermanager, ITokenManager tokenManager = null)
        {
            _userManager = usermanager; _tokenManager = tokenManager;
        }

        public async Task<TokenWrapper> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var IdentityUserTokenObj = await _userManager.GetUserTokenByRefreshToken(request.RefreshLoginToken);
            var user = await _userManager.GetUserById(IdentityUserTokenObj.UserId);
            var result = _tokenManager.GetPrincipalFromExpiredToken(request.LoginToken);


            var allowedRefreshes = Int32.Parse(result.Item1);
            var intervalOfUse = Int32.Parse(result.Item2);
            //1
            var expirationDate = Int32.Parse(result.Item3);
            DateTime tokenExpiration = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc); //.local
            tokenExpiration = tokenExpiration.AddSeconds(expirationDate).ToLocalTime();
            var jti = result.Item4;
            var roles = result.Item5.Split(',');


            //timespan


            if (IdentityUserTokenObj == null)
            {
                throw new WasNotAbleToRefreshTokenException("");
            }


            TokenWrapper tokenwrapper = new TokenWrapper();
            bool isTokenVerified = _tokenManager.IsTokenValid(request.LoginToken);
            if (isTokenVerified == true)
            {
                if (tokenExpiration < DateTime.UtcNow.AddHours(3))
                {
                    if (tokenExpiration.AddMinutes(intervalOfUse) >= DateTime.UtcNow)//addhours +2
                    {
                        if (allowedRefreshes != 0)
                        {
                            allowedRefreshes = allowedRefreshes - 1;
                            var claims = new ClaimsIdentity(new Claim[] {
                            new Claim(ClaimTypes.Email,user.Email),
                            new Claim(ClaimTypes.Name,user.Username),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.Jti,jti),
                            new Claim("NumberOfAllowedRefreshes",allowedRefreshes.ToString()),
                            new Claim("IntervalOfUseOfRefreshTokenAfterTokenHasExpired",intervalOfUse.ToString())


                        });
                            foreach (var role in roles)
                            {
                                claims.AddClaim(new Claim(ClaimTypes.Role, role));
                            }
                            var tuple = await _tokenManager.ReGenerateTokens(claims, IdentityUserTokenObj);

                            tokenwrapper.Token = tuple.Item1;
                            tokenwrapper.RefreshToken = tuple.Item2;
                            return tokenwrapper;

                        }
                        else
                        {
                            throw new MaximumRefreshesExceededException("You can't refresh the current token anymore. Please login again");
                        }



                        //se poate folosi refreshtoken ul si se face update in tabela IdentityUserToken cu un nou token si reftoken
                        //urmand sa se decrementeze NumberOfRefreshes pana cand =0

                    }
                    else
                    {
                        throw new IntervalOfRefreshTokenExpiredException("Please login again!");
                    }
                }
            }

            return tokenwrapper;


        }
    }
}
