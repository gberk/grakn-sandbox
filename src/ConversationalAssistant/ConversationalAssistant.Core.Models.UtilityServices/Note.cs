using System;
using System.Collections.Generic;
using System.Text;

namespace ConversationalAssistant.Core.Models.UtilityServices
{
    public class Note
    {
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
    }
}
