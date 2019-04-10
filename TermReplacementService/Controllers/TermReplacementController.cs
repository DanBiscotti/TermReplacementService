using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TermReplacementService.Code;
using TermReplacementService.Models.Responses;

namespace TermReplacementService.Controllers
{
    /// <summary>
    /// API Controller that handles exposes business logic of TermReplacement
    /// </summary>

    [Route("api/termreplacement")]
    [ApiController]
    public class TermReplacementController : ControllerBase
    {
        private readonly ITermReplacer _termReplacer;
        private readonly ISummaryBuilder _summaryBuilder;

        public TermReplacementController(ITermReplacer termReplacer, ISummaryBuilder summaryBuilder)
        {
            _termReplacer = termReplacer;
            _summaryBuilder = summaryBuilder;
        }

        /// <summary>
        /// Replaces terms in the integer range between lowerBound and upperBound
        /// </summary>
        /// <returns>Replace in range response</returns>
        // GET: api/TermReplacement/ReplaceInRange?lowerBound=3&upperBound=7
        [HttpGet]
        [Route("replaceinrange")]
        public ReplaceInRangeResponse ReplaceInRange([FromQuery(Name ="lowerBound")] int lowerBound, [FromQuery(Name ="upperBound")] int upperBound)
        {
            if (lowerBound > upperBound)
                throw new ArgumentException("lowerBound must be less than or equal to upperBound");

            var range = Enumerable.Range(lowerBound, (upperBound - lowerBound) + 1).ToArray();
            var termsReplaced = _termReplacer.ReplaceSequence(range);
            var summary = _summaryBuilder.BuildSummary(termsReplaced, range);
            return ReplaceInRangeResponse.Build(termsReplaced, range, summary);
        }
    }
}
