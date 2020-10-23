using ConversationalAssistant.Models;
using ConversationalAssistant.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversationalAssistant.Api.Controllers
{
    public class ContextObjectQueryController : ControllerBase
    {
        private readonly ContextObjectQueryService _queryService;

        public ContextObjectQueryController()
        {
            _queryService = new ContextObjectQueryService();
        }

        [HttpPost]
        public async Task<ContextObjectQueryResult> QueryContextObject([FromBody] ContextObject contextObject, [FromBody] string inputPhrase)
        {
            var result = _queryService.QueryContextObject(contextObject, inputPhrase);
            return result;
        }
    }
}
