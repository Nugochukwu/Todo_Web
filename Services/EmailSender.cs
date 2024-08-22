using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpServer = "your_smtp_server";
        private readonly int _smtpPort = 587; // Or the port number used by your SMTP server
        private readonly string _smtpUsername = "your_username";
        private readonly string _smtpPassword = "your_password";

        public Task SendEmailAsync(string email, string subject, string message)
        {
            // Implementation for sending a generic email
            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("Your App Name", _smtpUsername));
            mimeMessage.To.Add(new MailboxAddress("", email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("html") { Text = message };

            using (var client = new SmtpClient())
            {
                client.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                client.Authenticate(_smtpUsername, _smtpPassword);
                return client.SendAsync(mimeMessage);
            }
        }

        public async Task SendEmailConfirmationAsync(string email, string callbackUrl)
        {
            var subject = "Confirm your email";
            var message = $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>";

            await SendEmailAsync(email, subject, message);
        }
    }
}
