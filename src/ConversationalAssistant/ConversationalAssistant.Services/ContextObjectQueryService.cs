using ConversationalAssistant.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceResult;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversationalAssistant.Services
{
    public class ContextObjectQueryService
    {
        public Result<ContextObjectQueryResult> QueryContextObject(ContextObject contextObject, string input)
        {
            var languageModel = contextObject.LanguageModel;
            string winningPhrase = "";
            int? minDistance = null;
            foreach(var phrase in languageModel.ExtractionUtterances.Keys)
            {
                var ld = LevenshteinDistanceCalculator.Compute(input, phrase);
                if (!minDistance.HasValue)
                    minDistance = ld;

                if (ld <= minDistance)
                {
                    minDistance = ld;
                    winningPhrase = phrase;
                }
            }

            var matched = contextObject.LanguageModel.ExtractionUtterances.TryGetValue(winningPhrase, out var jsonPath);
            if (!matched)
                return null;

            JObject jo = JObject.Parse(JsonConvert.SerializeObject(contextObject.Data));
            var token = jo.SelectToken(jsonPath);

            return new SuccessResult<ContextObjectQueryResult>( new ContextObjectQueryResult
            {
                Data = JsonConvert.SerializeObject(token),
                JsonPathMatch = jsonPath,
                UtteranceMatch = winningPhrase,
                OriginalObject = contextObject
            });
        }
    }
}
