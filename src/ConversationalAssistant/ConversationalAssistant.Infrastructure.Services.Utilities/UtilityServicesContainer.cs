using ConversationalAssistant.Core.Models.Assistant.Responses;
using ConversationalAssitant.Core.Services.Utilities;
using ServiceResult;
using System;
using System.Threading.Tasks;

namespace ConversationalAssistant.Infrastructure.Services.Utilities
{
    public class UtilityServicesContainer : IUtlityServicesContainer
    {
        private readonly INoteTakingService _noteTakingService;
        public async Task<Result<AssistantServiceResponse>> ProbeForExactMatch(string userPhrase)
        {
            try
            {
                return await _noteTakingService.ProbeForExactMatch(userPhrase);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new UnexpectedResult<AssistantServiceResponse>();
            }
        }
    }
}
