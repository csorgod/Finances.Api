using System;
using System.Collections.Generic;
using System.Text;

namespace Finances.Core.Application.Notification.Models
{
    public class Message
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
