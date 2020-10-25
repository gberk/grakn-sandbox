using ConversationalAssistant.Core.Models.Assistant;
using ConversationalAssistant.Core.Models.Assistant.Constants;
using ConversationalAssistant.Core.Models.Assistant.Responses;
using ConversationalAssistant.Core.Models.UtilityServices;
using ConversationalAssistant.Core.Models.UtilityServices.Constants.Notes;
using ConversationalAssistant.Models;
using ConversationalAssitant.Core.Services.Utilities;
using Newtonsoft.Json;
using ServiceResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversationalAssistant.Infrastructure.Services.Utilities
{
    public class NoteTakingService : INoteTakingService
    {
        private readonly List<string> _simplePhrases = new List<string>
        {
            "take a note",
            "start a new note",
            "make a note"
        };

        public async Task<Result<AssistantServiceResponse>> ProbeForExactMatch(string userPhrase)
        {
            try
            {
                var result = new AssistantServiceResponse();
                if (_simplePhrases.Select(p => p.ToLower()).Contains(userPhrase.ToLower()))
                {

                    var note = new Note();

                    result.Match = new Match
                    {
                        Type = MatchTypes.Exact,
                        Phrase = userPhrase,
                        ServiceAction = new ServiceAction
                        {
                            Type = NoteActionTypes.CreateNote,
                        }
                    };
                    result.ContextObjects = new List<ContextObject>
                    {
                        new ContextObject
                        {
                            Type = note.GetType().ToString(),
                            LanguageModel = new LanguageModel                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               
                            {
                                ExtractionUtterances = new Dictionary<string, string>
                                {
                                    ["when was this note created"] = "createdDate"
                                }
                            },
                            Data = JsonConvert.SerializeObject(note)
                        }
                    };
                }

                return new InvalidResult<AssistantServiceResponse>("No exact match"); //How to represent a successful no-match response
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new UnexpectedResult<AssistantServiceResponse>();
            }
        }
    }
}
