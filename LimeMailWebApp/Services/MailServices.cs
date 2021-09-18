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
        public static List<Message> messages = new List<Message>();
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
            var getMessages = messages.Take(100);
            return getMessages;
        }

        public MailMessage GetById(int id)
        {
            var getMessageById = messages.Where(i => i.MailMessageId == id).FirstOrDefault();
            return getMessageById;
        }

        public static void GetMessages()
        {
            using (StreamReader r = new StreamReader("mail-messages.json"))
            {
                string mail = r.ReadToEnd();
                var message = JsonConvert.DeserializeObject<ResultList>(mail, new CustomJsonConverter());
                foreach(var m in message.mailMessages)
                {
                    Message mess = new();
                    mess = m;
                    messages.Add(mess);
                }
            }
        }
    }
}
