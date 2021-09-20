using Lime.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LimeMailWebApp.Models;

namespace LimeMailWebApp.Controllers
{
    public class MessageController : Controller
    {


        private readonly IMailMessageRepository _mailRepo;

        public MessageController(IMailMessageRepository mailRepo)
        {
            _mailRepo = mailRepo;
        }

        // GET: MessageController
        public ActionResult Index(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                IEnumerable<MailMessage> mails = _mailRepo.GetAll();
                return View(mails);
            }
            else
            {
                var foundMails = _mailRepo.Find(i => i.Name.ToUpper().Contains(name.ToUpper()));
                return View(foundMails);
            }

        }

        // GET: MessageController/Details/5
        public ActionResult Details(int id)
        {
            var message = _mailRepo.GetById(id);
            return View(message);
        }

        // GET: MessageController/Delete/5
        public ActionResult Delete(int id)
        {
            if (_mailRepo.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }


    }
}
