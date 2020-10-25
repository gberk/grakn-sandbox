﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConversationalAssistant.Models
{
    public class ContextObject
    {
        public string Type { get; set; }
        public string Data { get; set; }
        public LanguageModel LanguageModel { get; set; }
    }
}
