﻿using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using SurveyBasket.Settings;

namespace SurveyBasket.Services.Auth;

public class EmailService(IOptions<MailSettings> options) : IEmailSender
{
    private readonly MailSettings options = options.Value;

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var massage = new MimeMessage { 

            Sender = MailboxAddress.Parse(options.Mail),
            Subject = subject,

            };
        massage.To.Add(MailboxAddress.Parse(email));

        var builder = new BodyBuilder
        {
            HtmlBody = htmlMessage
        };

        massage.Body = builder.ToMessageBody();

        using var client = new SmtpClient();

        client.Connect(options.Host, options.Port, SecureSocketOptions.StartTls);

        client.Authenticate(options.Mail, options.Password);

        await client.SendAsync(massage);

        client.Disconnect(true);

    }
}
