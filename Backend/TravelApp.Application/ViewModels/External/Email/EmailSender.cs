using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Application.Common.Configurations;
using TravelApp.Application.Common.Interfaces;

namespace TravelApp.Application.ViewModels.External.Email
{
  public class EmailSender : IEmailSender
    {
        private readonly EmailSenderSetting _emailSenderSetting;
        public EmailSender(EmailSenderSetting emailSenderSetting)
        {
            _emailSenderSetting = emailSenderSetting;
        }
        /*public void SendEmail(MessageUsers message)
        {
            var emailMessage = CreateEmailMessage(message);
            SendEmail(emailMessage);
        }*/

        public async Task SendEmailAsync(MessageUsers message)
        {
            var emailMessage = CreateEmailMessage(message);
            await SendEmailAsync(emailMessage);
        }

        private MimeMessage CreateEmailMessage(MessageUsers message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_emailSenderSetting.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }
        private async Task SendEmailAsync(MimeMessage mailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailSenderSetting.SmtpServer, _emailSenderSetting.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailSenderSetting.Username, _emailSenderSetting.Password);

                    await client.SendAsync(mailMessage);
                }
                catch 
                {

                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                }
            }
        }
    }
}
