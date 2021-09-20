using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lime.Domain;
using LimeMailWebApp.Models;
using Newtonsoft.Json;
using LimeMailWebApp;
using LimeMailWebApp.Controllers;

namespace LimeMailWebApp.Services
{
    public class MailServices : IMailMessageRepository
    {
        public static List<Message> messages = new();

        public bool Delete(int id)
        {
            var deleteMail = messages.Where(i => i.Id == id).FirstOrDefault();
            if(deleteMail != null)
            {
                messages.Remove(deleteMail);
                return true;
            }
            else
            {
                return false;
            }
        }


        public IEnumerable<MailMessage> Find(Expression<Func<MailMessage, bool>> filter)
        {
            var mails = messages.Where(filter.Compile()).ToList();

            return mails;
        }

        public IEnumerable<MailMessage> GetAll()
        {
            var getMessages = messages.Take(100);
            return getMessages;
        }

        public MailMessage GetById(int id)
        {
            var getMessageById = messages.Where(i => i.MailMessageId == id).FirstOrDefault();
            return getMessageById;
        }

        public static IEnumerable<MailMessage> GetMessages()
        {
            using (StreamReader r = new StreamReader("mail-messages.json"))
            {
                string mail = r.ReadToEnd();
                var message = JsonConvert.DeserializeObject<ResultList>(mail, new CustomJsonConverter());
                foreach (var m in message.mailMessages)
                {
                    m.Id = m.MailMessageId;
                    messages.Add(m);
                }
                return message.mailMessages;
            }
            
        }


    }
}
