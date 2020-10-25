using ConversationalAssistant.Core.Models.Assistant.Responses;
using ConversationalAssistant.Core.Services.Assistant;
using ConversationalAssistant.Models.Requests.Assistants;
using ServiceResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalAssistant.Infrastructure.Services.Assistant
{
    public class AssistantService : IAssistant
    {
        private readonly IAssistantContextService _assistantContext;

        public AssistantService(IAssistantContextService assistantContext)
        {
            _assistantContext = assistantContext;
        }

        public async Task<Result<AssistantServiceResponse>> MakeRequest(AssistantRequest request)
        {
            try
            {
                return await _assistantContext.ProbeForSimpleMatch(request.UserPhrase);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new UnexpectedResult<AssistantServiceResponse>();
            }
        }
    }
}
