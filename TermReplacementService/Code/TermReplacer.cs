using Microsoft.Extensions.Options;
using TermReplacementService.Models.Configuration;

namespace TermReplacementService.Code
{
    public class TermReplacer : ITermReplacer
    {
        private readonly TermReplacementConfiguration _config;

        public TermReplacer(IOptions<TermReplacementConfiguration> config)
        {
            _config = config.Value;
        }

        /// <summary>
        /// Replaces all elements in a given sequence by calling Replace term on each.
        /// </summary>
        public string[] ReplaceSequence(int[] input)
        {
            var result = new string[input.Length];
            for (int i = 1; i <= input.Length; i++)
                result[i - 1] = ReplaceTerm(input[i - 1]);
            return result;
        }

        public string ReplaceTerm(int term)
        {
            string result = null;
            foreach (var setting in _config.ReplaceTermSettings) 
                if (term % setting.MultipleOf == 0)
                    result = (result == null) ? setting.ReplaceWith : result + setting.ReplaceWith;
            return result;
        }
    }
}
