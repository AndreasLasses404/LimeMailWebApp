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

        // GET: MessageController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MessageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MessageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MessageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MessageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
