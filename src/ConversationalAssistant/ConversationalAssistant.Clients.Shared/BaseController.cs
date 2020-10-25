﻿using Microsoft.AspNetCore.Mvc;
using ServiceResult;
using System;

namespace ConversationalAssistant.Clients.Shared
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Creates an action result from a generic result
        /// </summary>
        /// <returns>The result.</returns>
        /// <param name="result">Result.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        protected ActionResult FromResult<T>(Result<T> result)
        {
            switch (result.ResultType)
            {
                case ResultType.Ok:
                    return Ok(result.Data);
                case ResultType.NotFound:
                    return NotFound(result.Errors);
                case ResultType.Invalid:
                    return BadRequest(result.Errors);
                case ResultType.Unexpected:
                    return BadRequest(result.Errors);
                case ResultType.Unauthorized:
                    return Unauthorized();
                default:
                    throw new Exception("An unhandled result has occurred as a result of a service call.");
            }
        }
    }
}
