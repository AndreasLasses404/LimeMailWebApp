using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimeMailWebApp.Models
{
    public class ResultList
    {
        public IEnumerable<Message> mailMessages { get; set; }
    }
}
