using ConversationalAssistant.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConversationalAssistant.Core.Models.Assistant.Responses
{
    public class AssistantServiceResponse
    {
        public Match Match { get; set; }
        public List<ContextObject> ContextObjects { get; set; }
    }
}
