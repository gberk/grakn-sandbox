using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConversationalAssistant.Clients.Shared;
using ConversationalAssistant.Core.Services.Assistant;
using ConversationalAssistant.Models.Requests.Assistants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConversationalAssistant.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssistantController : BaseController
    {
        private readonly IAssistant _assistant;

        public AssistantController(IAssistant assistant)
        {
            _assistant = assistant;
        }

        [HttpPost("request")]
        public async Task<IActionResult> AssistantRequest([FromBody] AssistantRequest request)
        {
            var result = await _assistant.MakeRequest(request);
            return FromResult(result);
        }
    }
}