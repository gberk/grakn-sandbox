using ConversationalAssistant.Core.Models.Assistant.Responses;
using ServiceResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalAssistant.Core.Services.Assistant
{
    public interface IAssistantContextService
    {
        Task<Result<AssistantServiceResponse>> ProbeForSimpleMatch(string userPhrase);
    }
}
