using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Steunijos.Web.Data;
using Steunijos.Web.Models;
using Steunijos.Web.ViewModels.ContactUs;

namespace Steunijos.Web.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly IConfiguration _config;
        private readonly SteunijosContext _db;

        public ContactUsController(IConfiguration config, SteunijosContext db)
        {
            _config = config;
            _db = db;
        }
        // GET: Contact
        public async Task<ActionResult> Index()
        {
            //get all correspondence sent successfully and show it here.
            var result = await _db.ContactUsSubmissions.AsNoTracking()
                .Select(c => new ContactUsViewModel
                {
                    EmailAddress = c.SendersEmail,
                    FullName = c.SendersFullName,
                    MessageType = c.MessageType,
                    SubmissionDate = c.SubmissionDate,
                    SubmissionId = c.SubmissionId,
                    SubmittedMessage = c.MessageSent
                }).ToListAsync().ConfigureAwait(false);
            return View(result);
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            //show the message sent by its id
            var details = new ContactUsDetailModel();
            return View(details);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            var contactInput = new ContactUsInputModel();
            return View(contactInput);
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendContact(ContactUsInputModel sent)
        {
            SmtpClient client;
            try
            {
                if (ModelState.IsValid)
                {
                    var username = _config.GetValue<string>("Gmail:Username");
                    var password = _config.GetValue<string>("Gmail:Password");
                    client = new SmtpClient
                    {
                        Host = _config.GetValue<string>("Gmail:Host"),
                        Port = _config.GetValue<int>("Gmail:Port"),
                        EnableSsl = bool.Parse(_config["Gmail:SMTP:starttls:enable"]),
                        Credentials = new NetworkCredential(username, password)
                    };
                    
                    var mail = new MailMessage(sent.EmailAddress, username);
                    mail.Subject = sent.MessageType.ToString();
                    mail.Body = sent.Message;
                    mail.IsBodyHtml = true;
                    
                    client.Send(mail);

                    var contactSubmit = new ContactUsSubmission
                    {
                        MessageSent = sent.Message,
                        MessageSubject = sent.MessageType.ToString(),
                        MessageType = sent.MessageType.ToString(),
                        SendersEmail = sent.EmailAddress,
                        SubmissionDate = DateTimeOffset.UtcNow.LocalDateTime,
                        ReceivingEmailAddress = username,
                        SendersFullName = sent.FullName,
                        SubmissionId = sent.MessageId
                    };
                    _db.ContactUsSubmissions.Add(contactSubmit);
                    await _db.SaveChangesAsync();
                }
                return RedirectToRoute(new {controller = "Home", action = "Index"});
            }
            catch
            {
                return View("Create");
            }
            
        }
    }
}