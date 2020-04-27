using EasyDo.Models;
using System.Collections.Generic;

namespace EasyDo.Services.Emails
{
    public interface IEmailsService
    {
        public List<EmailViewModel>GetAllEmails();
        public EmailViewModel SaveEmail(EmailViewModel model, int id);
        public EmailViewModel GetId(int id);
    }
}
