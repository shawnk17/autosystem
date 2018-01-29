using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entities
{
    public class Telegram
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
    }
}
