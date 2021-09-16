using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Lime.Domain;
using LimeMailWebApp.Models;
using Newtonsoft.Json;

namespace LimeMailWebApp.Services
{
    public class MailServices : IMailMessageRepository
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MailMessage> Find(Expression<Func<MailMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MailMessage> GetAll()
        {
            var message = GetMessages();
            return message.Take(100);
        }

        public MailMessage GetById(int id)
        {
            var message = GetMessages();
            return message.Where(i => i.MailMessageId == id).FirstOrDefault();
        }

        public IEnumerable<Message> GetMessages()
        {
            using (StreamReader r = new StreamReader("mail-messages.json"))
            {
                string mail = r.ReadToEnd();
                var message = JsonConvert.DeserializeObject<ResultList>(mail, new CustomJsonConverter());

                return message.mailMessages;
            }
        }
    }
}
