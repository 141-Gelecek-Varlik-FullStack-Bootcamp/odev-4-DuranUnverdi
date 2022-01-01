using BusinessLayer.Model;
using BusinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace patikahafta4.Infrastructure
{
    public class MailJob
    {
        private readonly IMailService _emailService;
        public MailJob(IMailService emailService)
        {
            _emailService = emailService;
        }
        public void SendWelcomeMail(string ToUser, string ToUserMail)
        {
            var newMail = new Email() { To = ToUser, ToMail = ToUserMail };
            newMail.From = "";
            newMail.FromMail = "duranunverdi1905@gmail.com";
            newMail.Subject = string.Format("Welcome {0},Üye Olduğunuz için teşekkür ederiz!", ToUser);
            newMail.Body = string.Format("Hello {0}, \n Hoş Geldiniz", ToUser);
            newMail.SmtpPass = "duranunverdi1905";
            _emailService.Send(newMail);
        }
    }
}
