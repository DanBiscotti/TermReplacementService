using System;

namespace TermReplacementService.Models.Configuration
{
    public class ReplaceTermSetting
    {
        public ReplaceTermSetting()
        {
        }

        public ReplaceTermSetting(int multipleOf, string replaceWith)
        {
            if (string.IsNullOrEmpty(replaceWith))
                throw new ArgumentException("replaceWith must not be null or empty");
            if (multipleOf<1)
                throw new ArgumentException("multipleOf must be a positive, non-zero integer");
            MultipleOf = multipleOf;
            ReplaceWith = replaceWith;
        }

        public int MultipleOf { get; set; }
        public string ReplaceWith { get; set; }
    }
}
