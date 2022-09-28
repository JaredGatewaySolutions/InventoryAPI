using InventoryAPI.Controllers;
using InventoryAPI.Models;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using InventoryAPI.Services.Interfaces;

namespace InventoryAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfig;
        private readonly IConfiguration _config;
        private readonly ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger,
        EmailConfiguration emailConfig,
            IConfiguration config)
        {
            _logger = logger;
            _emailConfig = emailConfig;
            _config = config;
        }

        public bool SendEmail(EmailMessage message)
        {
            var mailMessage = CreateEmailMessage(message);

            return Send(mailMessage);
        }

        public Task<bool> SendEmailAsync(EmailMessage message)
        {
            var mailMessage = CreateEmailMessage(message);

            return SendAsync(mailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailConfig.UserName, _emailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;

            var bodyBuilder = new BodyBuilder { HtmlBody = string.Format("<h2 style='color:red;'>{0}</h2>", message.Content) };

            if (message.Attachments != null && message.Attachments.Any())
            {
                foreach (var attachment in message.Attachments)
                {
                    bodyBuilder.Attachments.Add(attachment);
                }
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();
            return emailMessage;
        }

        private bool Send(MimeMessage mailMessage)
        {
            var result = false;
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_emailConfig.UserName, _emailConfig.AppPassword);

                    client.Send(mailMessage);
                    client.Disconnect(true);
                    result = true;
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception, or both.
                    _logger.LogError(ex, "SENDING EMAIL FAILED");
                    result = false;
                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
            }
            return result;
        }

        private async Task<bool> SendAsync(MimeMessage mailMessage)
        {
            var result = false;
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.AppPassword);

                    await client.SendAsync(mailMessage);
                    result = true;
                }
                catch (Exception ex)
                {
                    //log an error message or throw an exception, or both.
                    _logger.LogError(ex, "SENDING EMAIL FAILED");
                    result = false;
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
            return result;
        }
    }
}
