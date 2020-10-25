using ConversationalAssistant.Core.Models.Assistant.Responses;
using ServiceResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalAssitant.Core.Services.Utilities
{
    public interface IAssistantService
    {
        Task<Result<AssistantServiceResponse>> ProbeForExactMatch(string userPhrase);
    }
}
