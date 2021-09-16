using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lime.Domain;

namespace LimeMailWebApp.Models
{
    public class Message : MailMessage
    {
        public int MailMessageId { get; set; }
    }
}
