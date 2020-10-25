using ConversationalAssistant.Core.Models.Assistant.Responses;
using ConversationalAssistant.Core.Services.Assistant;
using ConversationalAssitant.Core.Services.Utilities;
using ServiceResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalAssistant.Infrastructure.Services.Assistant
{
    public class AssistantContextService : IAssistantContextService
    {
        private readonly IUtlityServicesContainer _utilityServices;

        public AssistantContextService(IUtlityServicesContainer utilityServices)
        {
            _utilityServices = utilityServices;
        }

        public async Task<Result<AssistantServiceResponse>> ProbeForSimpleMatch(string userPhrase)
        {
            try
            {
                return await _utilityServices.ProbeForExactMatch(userPhrase);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new UnexpectedResult<AssistantServiceResponse>();
            }
        }
    }
}
