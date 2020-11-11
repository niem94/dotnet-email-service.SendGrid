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
           Action<SendGridOptions> options)
        {
            services.Configure(options);
            services.AddTransient<IEmailService, SendGridEmailService>();
        }

        public static void AddSendGridEmailService(this IServiceCollection services,
           SendGridOptions options)
        {
            services.ConfigureOptions(options);
            services.AddTransient<IEmailService, SendGridEmailService>();
        }
    }
}