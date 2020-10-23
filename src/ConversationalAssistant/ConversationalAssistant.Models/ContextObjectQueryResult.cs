using System.Collections.Generic;

namespace ConversationalAssistant.Models
{
    public class ContextObjectQueryResult
    {
        public ContextObject OriginalObject { get; set; }
        public string UtteranceMatch { get; set; }
        public string JsonPathMatch { get; set; }
        public string Data { get; set; }
    }
}