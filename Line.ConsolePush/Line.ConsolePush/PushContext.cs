using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line.ConsolePush
{
    public class PushContext
    {
        public string to { get; set; }
        public List<Message> messages { get; set; } = new List<Message>();
    }

    public class Message
    {
        public string type { get; set; }
        public string text { get; set; }
    }
}
