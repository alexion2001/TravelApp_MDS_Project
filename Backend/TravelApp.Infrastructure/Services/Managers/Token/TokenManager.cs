using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Configurations;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Domain.Entities;
using TravelApp.Domain.Enums;
using TravelApp.Infrastructure.Persistence.DbContexts.Travel;

namespace TravelApp.Infrastructure.Services.Managers.Token
{
    public class TokenManager : ITokenManager
    {
        private readonly TravelDbContext _context;
        private readonly RefreshTokenConfig _refreshTokenConfig;
        private readonly SignInKeySetting _signInKeySetting;
        private readonly LoginTokenConfig _loginTokenConfig;
        public TokenManager(TravelDbContext context, RefreshTokenConfig refreshTokenConfig, SignInKeySetting signInKeySetting, LoginTokenConfig loginTokenConfig)
        {
            _context = context;
            _refreshTokenConfig = refreshTokenConfig;
            _signInKeySetting = signInKeySetting;
            _loginTokenConfig = loginTokenConfig;
        }



        public async Task<Tuple<string, string>> GenerateTokenAndRefreshToken(SymmetricSecurityKey signinKey, IdentityUser user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string newJti)
        {

            var token = GenerateJwtToken(signinKey, user, roles, tokenHandler, newJti);
            string tokenStringValue = tokenHandler.WriteToken(token);
            var refreshToken = GenerateRefreshToken();

            _context.Set<IdentityUserToken>().Add(new IdentityUserToken()
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                TokenValue = tokenStringValue,
                RefreshTokenValue = refreshToken,
                CreationDate = token.ValidFrom,
                ExpirationDate = token.ValidTo
            });

            await _context.SaveChangesAsync();
            var tuple = new Tuple<string, string>(tokenStringValue, refreshToken);
            return tuple;

        }

        private SecurityToken GenerateJwtToken(SymmetricSecurityKey signinKey, IdentityUser user, List<string> roles, JwtSecurityTokenHandler tokenHandler, string newJti)
        {


            var subject = new ClaimsIdentity(new Claim[] {
                     new Claim(ClaimTypes.Email,user.Email),
                     new Claim(ClaimTypes.Name,user.Username),
                     new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                     new Claim(JwtRegisteredClaimNames.Jti,newJti),
                     new Claim("NumberOfAllowedRefreshes",_refreshTokenConfig.NumberOfRefreshes),
                     new Claim("IntervalOfUseOfRefreshTokenAfterTokenHasExpired",_refreshTokenConfig.TimeLeftUntilRefreshTokenExpiresAfterTokenAlreadyExpired)


             });
            foreach (var role in roles)
            {
                subject.AddClaim(new Claim(ClaimTypes.Role, role));
            }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Issuer = _refreshTokenConfig.Issuer,
                Audience = _refreshTokenConfig.Audience,
                // Expires = DateTime.UtcNow.AddDays(Int32.Parse(_loginTokenConfig.Days)),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return token;
        }

        public async Task<IdentityUserTokenConfirmation> CreateConfirmationToken(Guid userId, ConfirmationTokenType tokenType)
        {
            var res = await GetActiveConfirmationTokens(userId).ToListAsync();
            foreach (var tokens in res)
            {
                tokens.IsRevoked = true;
            }

            var confirmationToken = new IdentityUserTokenConfirmation();
            confirmationToken.Id = Guid.NewGuid();
            // confirmationToken.UserId = user.Id;
            confirmationToken.UserId = userId;
            confirmationToken.ConfirmationTypeId = tokenType;
            confirmationToken.CreationDate = DateTime.UtcNow;
            confirmationToken.ExpireDate = DateTime.UtcNow.AddDays(Int32.Parse(_loginTokenConfig.Days)); //addhours
            confirmationToken.ConfirmationToken = Guid.NewGuid().ToString();
            _context.Set<IdentityUserTokenConfirmation>().Add(confirmationToken);
            await _context.SaveChangesAsync();
            return confirmationToken;

        }

        public async Task<IdentityUserTokenConfirmation> GetUserActiveConfirmationToken(Guid userId, string tokenValue, ConfirmationTokenType tokenType)
        {
            var token = await GetActiveConfirmationTokens(userId)
                .Where(token =>
                    token.ConfirmationTypeId == tokenType &&
                    token.ConfirmationToken == tokenValue && token.ExpireDate > DateTime.UtcNow
                 )
                .SingleOrDefaultAsync();

            return token;
        }

        private IQueryable<IdentityUserTokenConfirmation> GetActiveConfirmationTokens(Guid userId)
        {
            var activeTokens = _context.IdentityUserTokenConfirmations
                .Where(utc =>
                    utc.UserId.Equals(userId) &&
                    utc.IsRevoked == false &&
                    utc.IsUsed == false &&
                    utc.ExpireDate > DateTime.UtcNow
                 )
                .AsQueryable();
            return activeTokens;
        }


        public async Task MarkRecoveryTokenAsUsed(IdentityUserTokenConfirmation obj)
        {
            obj.IsUsed = true;
            await _context.SaveChangesAsync();
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        public Tuple<string, string, string, string, string> GetPrincipalFromExpiredToken(string token)
        {


            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var decodedToken = jsonToken as JwtSecurityToken;

            var jti = decodedToken.Claims.First(claim => claim.Type.Equals("jti")).ToString().Split(':')[1];
            var roles = decodedToken.Claims.First(claim => claim.Type.Equals("role")).ToString().Split(':')[1];  //?
            var allowedRefreshes = decodedToken.Claims.First(claim => claim.Type.Equals("NumberOfAllowedRefreshes")).ToString().Split(':')[1]; //
            var intervalOfUse = decodedToken.Claims.First(claim => claim.Type.Equals("IntervalOfUseOfRefreshTokenAfterTokenHasExpired")).ToString().Split(':')[1]; //
            var expirationDate = decodedToken.Claims.First(claim => claim.Type.Equals("exp")).ToString().Split(':')[1]; //

            var tuple = new Tuple<string, string, string, string, string>(allowedRefreshes, intervalOfUse, expirationDate, jti, roles);
            return tuple;

        }

        public async Task<Tuple<string, string>> ReGenerateTokens(ClaimsIdentity claims, IdentityUserToken usertoken)
        {
            var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signInKeySetting.SecretSignInKeyForJwtToken));
            var refreshToken = GenerateRefreshToken();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Issuer = _refreshTokenConfig.Issuer,
                Audience = _refreshTokenConfig.Audience,
                // Expires = DateTime.UtcNow.AddMinutes(Int32.Parse(_loginTokenConfig.Minutes)), 
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenStringValue = tokenHandler.WriteToken(token);
            usertoken.TokenValue = tokenStringValue;
            usertoken.RefreshTokenValue = refreshToken;
            usertoken.CreationDate = token.ValidFrom;
            usertoken.ExpirationDate = token.ValidTo;
            await _context.SaveChangesAsync();
            var tuple = new Tuple<string, string>(tokenStringValue, refreshToken);
            return tuple;
        }

        public bool IsTokenValid(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = true, // folosit sa valized audience si issuer setate in app.json
                ValidateIssuer = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_signInKeySetting.SecretSignInKeyForJwtToken)),
                ValidateLifetime = true,
                ValidIssuer = _refreshTokenConfig.Issuer,
                ValidAudience = _refreshTokenConfig.Audience
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            IPrincipal principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);
            return true;
        }
    }
}
