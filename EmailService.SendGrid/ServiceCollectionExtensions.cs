using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmailService.SendGrid
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