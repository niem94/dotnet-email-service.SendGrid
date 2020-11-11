# dotnet-email-service
A collection of providers with an easy api for sending mails from dotnet.

Currently supports sending simple emails from SendGrid or SMTP.

## Set up
Call the service collection method `services.AddEmailService(MailSettings mailSettings)` from the Startup class, and then you can inject the `IEmailService` where needed.
Configuring the provider is done from properties on the MailSettings object.
