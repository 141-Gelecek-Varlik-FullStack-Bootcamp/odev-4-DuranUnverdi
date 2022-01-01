using BusinessLayer.Abstract;
using BusinessLayer.Model;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MailManager : IMailService
    {
        public void Send(Email mail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(mail.From, mail.FromMail));
            message.To.Add(new MailboxAddress(mail.To, mail.ToMail));
            message.Subject = mail.Subject;
            message.Body = new TextPart("plain")
            {
                Text = mail.Body
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(mail.FromMail, mail.SmtpPass);
                smtp.Send(message);
                smtp.Disconnect(true);
            }
        }
        //public Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    MailMessage mail = new MailMessage
        //    {
        //        From = new MailAddress("cihan.metix@gmail.com", "TEGV DiJİTAL", System.Text.Encoding.UTF8),
        //        Subject = subject,
        //        Body = htmlMessage,
        //        IsBodyHtml = true,
        //    };
        //    mail.To.Add(email);
        //    SmtpClient smp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential("cihan.metix@gmail.com", "M3t!x321"),
        //        Port = 587,
        //        EnableSsl = true,
        //    };
        //    smp.Send(mail);

        //    return Task.CompletedTask;
        //}
    }
}
