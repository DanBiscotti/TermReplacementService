using System.Collections.Generic;
using TermReplacementService.Models;

namespace TermReplacementService.Code
{
    /// <summary>
    /// A helper class that replaces integer terms with strings depending on the factors of the integer.
    /// </summary>
    public interface ITermReplacer
    {
        /// <summary>
        /// Takes an array of integers and conditionally replaces them with strings based on rules.
        /// </summary>
        /// <returns>string array. null used if int at index has not been replaced.</returns>
        string[] ReplaceSequence(int[] input);
    }
}