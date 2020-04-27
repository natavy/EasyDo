
namespace EasyDo.Controllers
{
    using System;
    using System.Net.Mail;
    using EasyDo.Data;
    using EasyDo.Models;
    using EasyDo.Services;
    using EasyDo.Services.Emails;
    using Microsoft.AspNetCore.Mvc;

    public class EmailController : Controller
    {
        private readonly EasyDoDbContext db;
        private readonly IEmailsService emails;
        private readonly IContactsService contacts;

        public EmailController(EasyDoDbContext db, IEmailsService emails, IContactsService contacts)
        {
            this.db = db;
            this.emails = emails;
            this.contacts = contacts;
        }

        [HttpGet]
        public IActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendEmail(EmailViewModel model, int id)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    emails.SaveEmail(model, id);
                    var to = contacts.GetContactById(id).Email;
                    var subject = model.Subject;
                    var message = model.Message;
                    MailMessage mailMessage = new MailMessage();
                    mailMessage.From = new MailAddress("test@gmail.com", "Natasha Dimova");
                    mailMessage.To.Add(to);
                    mailMessage.Subject = subject;
                    mailMessage.Body = message;
                    mailMessage.IsBodyHtml = false;
                    //add host
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.UseDefaultCredentials = true;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = new System.Net.NetworkCredential("test@gmail.com", "*******");
                    smtp.Send(mailMessage);
                    ViewBag.Success = "";
                    return View();
                }
                catch (Exception ex)
                {

                    return View(ex.Message);
                }
                
            }
            else
            {
                ViewBag.Failed = "This action could not be completed. Try again!";
                return View();
            }

        }
    }
}

    
