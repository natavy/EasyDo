
namespace EasyDo.Services.Emails
{
    using EasyDo.Data;
    using EasyDo.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class EmailsService : IEmailsService
    {
        private readonly EasyDoDbContext db;
        public EmailsService(EasyDoDbContext db)
        {
            this.db = db;
        }

        public List<EmailViewModel> GetAllEmails()
        {
            var emails = this.db.Emails
                .Select(e => new EmailViewModel
                {
                    Id=e.Id,
                    Subject=e.Subject,
                    Message=e.Message

                }).ToList();
            return emails;
        }

        public EmailViewModel GetId(int id)
        {
            var email = db.Emails.Where(c => c.Id == id).FirstOrDefault();
            return new EmailViewModel
            {
                Id = email.Id

            };
        }

        public EmailViewModel SaveEmail(EmailViewModel model,int id)
        {
            SendEmail email = new SendEmail
            {
                    
                    Subject= model.Subject,
                    Message=model.Message,
                    ContactId=id

            };
            db.Emails.Add(email);
            db.SaveChanges();
            return model;
        }
    }
}
