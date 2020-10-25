using System;
using System.Collections.Generic;
using System.Text;

namespace ConversationalAssistant.Core.Models.Assistant.Responses
{
    public class Match
    {
        public string Phrase { get; set; }
        public ServiceAction ServiceAction { get; set; }
        public string Type { get; set; }
    }
}
