using System.Collections.Generic;

namespace TermReplacementService.Code
{
    /// <summary>
    /// A helper class that generates summaries of the frequency of replaced terms
    /// in a given collection.
    /// </summary>
    public interface ISummaryBuilder
    {
        /// <summary>
        /// Calculate a summary containing the frequency of terms which have been replaced.
        /// </summary>
        /// <returns>A dictionary where key=term and value=frequency</returns>
        Dictionary<string, int> BuildSummary(string[] termsReplaced, int[] originalNumbers);
    }
}