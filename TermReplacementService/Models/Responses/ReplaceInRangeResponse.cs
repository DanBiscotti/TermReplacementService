using System.Collections.Generic;

namespace TermReplacementService.Models.Responses
{
    /// <summary>
    /// ReplaceInRangeResponse is a response returned from the TermReplacerController.
    /// When instatiating, it will join a string array separated by spaces.
    /// </summary>
    public class ReplaceInRangeResponse
    {
        public static ReplaceInRangeResponse Build(string[] termsReplaced, int[] originalNumbers, Dictionary<string, int> summary)
        {
            for (int i = 1; i <= termsReplaced.Length; i++)
                if (termsReplaced[i - 1] == null)
                    termsReplaced[i - 1] = originalNumbers[i - 1].ToString();
            var joined = string.Join(" ", termsReplaced);
            return new ReplaceInRangeResponse {result = joined, summary=summary};
        }

        public ReplaceInRangeResponse()
        {
            
        }

        public string result { get; set; }
        public Dictionary<string,int> summary { get; set; }
    }
}
