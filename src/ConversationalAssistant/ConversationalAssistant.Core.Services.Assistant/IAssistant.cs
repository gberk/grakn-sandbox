using ConversationalAssistant.Core.Models.Assistant.Responses;
using ConversationalAssistant.Models.Requests.Assistants;
using ServiceResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalAssistant.Core.Services.Assistant
{
    public interface IAssistant
    {
        Task<Result<AssistantServiceResponse>> MakeRequest(AssistantRequest request);
    }
}
