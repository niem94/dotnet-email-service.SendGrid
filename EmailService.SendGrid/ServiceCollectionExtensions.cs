using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using EmailService.Smtp;
using EmailService.SendGrid;

namespace EmailService
{
    public static class ServiceCollectionExtensions
    {
        public static void AddSendGridEmailService(this IServiceCollection services,
           Action<SendGridSettings> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SendGridEmailService>();
        }

        public static void AddSendGridEmailService(this IServiceCollection services,
           SendGridSettings options)
        {
            services.ConfigureOptions(options);
            services.AddTransient<IEmailService, SendGridEmailService>();
        }
    }
}