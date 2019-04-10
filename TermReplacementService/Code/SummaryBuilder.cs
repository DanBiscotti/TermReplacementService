using System.Collections.Generic;

namespace TermReplacementService.Code
{
    /// <inheritdoc />
    public class SummaryBuilder : ISummaryBuilder
    {
        /// <inheritdoc />
        public Dictionary<string, int> BuildSummary(string[] termsReplaced, int[] originalNumbers)
        {
            var result = new Dictionary<string, int>(new[] {new KeyValuePair<string,int>("Integer",0)});
            for(int i=1;i<=termsReplaced.Length;i++)
            {
                if (termsReplaced[i - 1] == null)
                    result["Integer"]++;
                else
                {
                    if (!result.ContainsKey(termsReplaced[i - 1]))
                        result[termsReplaced[i - 1]] = 1;
                    else
                        result[termsReplaced[i - 1]]++;
                }
            }
            return result;
        }
    }
}
