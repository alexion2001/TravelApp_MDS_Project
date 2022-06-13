using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Configurations;
using TravelApp.Application.Common.Interfaces;
using TravelApp.Application.Features.PasswordHashing;
using TravelApp.Application.ViewModels.External.Email;
using TravelApp.Infrastructure.Persistence.DbContexts.Travel;
using TravelApp.Infrastructure.Services.Managers.Email;
using TravelApp.Infrastructure.Services.Managers.Istoric;
using TravelApp.Infrastructure.Services.Managers.Recenzii;
using TravelApp.Infrastructure.Services.Managers.Token;
using TravelApp.Infrastructure.Services.Managers.Users;
using TravelApp.Infrastructure.Services.Managers.WebScraping;

namespace TravelApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContexts(configuration);


            services.AddScoped<IHashAlgo, HashAlgo>();
            services.AddSignInKeyConfiguration(configuration);
            services.AddRefreshTokenConfiguration(configuration);
            services.AddLoginTokenConfiguration(configuration);
            services.AddScoped<IWebScrapingManager, WebScrapingManager>();
            services.AddScoped<IIstoricCazariManager, IstoricCazariManager>();
            services.AddScoped<IIstoricZborManager, IstoricZborManager>();
            services.AddScoped<ICazariUsersManager, CazariUsersManager>();
            services.AddScoped<IZboruriUsersManager, ZboruriUsersManager>();
            services.AddScoped<IRecenziiManager, RecenziiManager>();
            services.AddScoped<IRecenziiUserManager, RecenziiUserManager>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IEmailSender, EmailSender>();
            services.AddScoped<IEmailManager, EmailManager>();
            services.AddEmailConfiguration(configuration);
            return services;
        }
        private static IServiceCollection AddSignInKeyConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var signinConfig = configuration.GetSection(SignInKeySetting.NAME).Get<SignInKeySetting>();
            //Console.WriteLine(signinConfig.SecretSignInKeyForJwtToken);
            services.AddSingleton(signinConfig);
            return services;

        }

        private static IServiceCollection AddLoginTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var logintokenConfig = configuration.GetSection(LoginTokenSetting.NAME).Get<LoginTokenSetting>();
            if (logintokenConfig.LoginTokenConfigs.TryGetValue(LoginTokenIdentifier.LoginToken, out var loginTokenConfig) == false)
            {

                throw new Exception();
            }
            // Console.WriteLine(loginTokenConfig.Minutes);
            services.AddSingleton(loginTokenConfig);
            return services;

        }
        private static IServiceCollection AddRefreshTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var reftokenConfig = configuration.GetSection(RefreshTokenSetting.NAME).Get<RefreshTokenSetting>();
            if (reftokenConfig.RefreshTokenConfigs.TryGetValue(RefreshTokenIdentifier.RefreshToken, out var refreshTokenConfig) == false)
            {

                throw new Exception();
            }
            //Console.WriteLine(refreshTokenConfig.Issuer);
            services.AddSingleton(refreshTokenConfig);
            return services;
        }

        private static IServiceCollection AddEmailConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration.GetSection(EmailSenderSetting.NAME).Get<EmailSenderSetting>();

            // Console.WriteLine(emailConfig.Password);
            services.AddSingleton(emailConfig);

            return services;
        }
        private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionOptions = configuration.GetSection(ConnectionStringSetting.NAME).Get<ConnectionStringSetting>();


            if (connectionOptions.ConnectionStringConfigs.TryGetValue(DatabaseIdentifier.TravelDatabase, out var TravelDbConfig) == false)
            {

                throw new ArgumentException($"{nameof(DatabaseIdentifier.TravelDatabase)} was not found in the dbConfig!");
            }
            Console.WriteLine(TravelDbConfig.ConnectionString);
            services.AddDbContext<TravelDbContext>(options =>
            {
                options.UseSqlServer(TravelDbConfig.ConnectionString, configOption =>
                {
                    configOption.CommandTimeout(TravelDbConfig.TimeoutSeconds);
                });
            });

            return services;
        }

    }
}
