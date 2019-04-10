using Microsoft.Extensions.Options;
using System.Collections.Generic;
using TermReplacementService.Code;
using TermReplacementService.Models.Configuration;
using Xunit;

namespace TermReplacementService.Tests.Code
{
    public class TermReplacerTests
    {
        [Theory]
        [ClassData(typeof(ReplaceSequenceTestData))]
        public void ReplaceSequence_WhenGivenIntArray_ReturnsArrayWithTermsReplaced(int[] input, string[] expected, ReplaceTermSetting[] settings)
        {
            // Arrange
            var config = new TermReplacementConfiguration() { ReplaceTermSettings = settings };
            var termReplacer = new TermReplacer(Options.Create<TermReplacementConfiguration>(config));

            // Act
            var result = termReplacer.ReplaceSequence(input);

            // Assert
            Assert.Equal(expected, result);
        }
        
        // Test cases
        class ReplaceSequenceTestData : TestData
        {
            public override IEnumerator<object[]> GetTestCases()
            {
                // 1 setting
                yield return new object[]
                {
                    new[] {1, 2, 3, 4},
                    new[] {null, "Hello", null, "Hello"},
                    new[] {new ReplaceTermSetting(2, "Hello")}
                };
                // 2 settings concatenated
                yield return new object[]
                {
                    new[] {1, 2, 3, 4, 5, 6},
                    new[] {null, "Hello", "There", "Hello", null, "HelloThere"},
                    new[] {new ReplaceTermSetting(2, "Hello"), new ReplaceTermSetting(3, "There")}
                };
            }
        }

        [Theory]
        [ClassData(typeof(ReplaceTermTestData))]
        public void ReplaceTerm_WhenGivenTerm_ReplacesDependingOnSetting(int input, string expected,
            ReplaceTermSetting[] settings)
        {
            // Arrange
            var config = new TermReplacementConfiguration() { ReplaceTermSettings = settings };
            var termReplacer = new TermReplacer(Options.Create<TermReplacementConfiguration>(config));

            // Act
            var result = termReplacer.ReplaceTerm(input);

            // Assert
            Assert.Equal(expected, result);
        }

        // Test cases
        class ReplaceTermTestData : TestData
        {
            public override IEnumerator<object[]> GetTestCases()
            {
                // Input is multiple
                yield return new object[]
                {
                    2,
                    "Hello",
                    new[] {new ReplaceTermSetting(2, "Hello")}
                };
                // Input is not multiple
                yield return new object[]
                {
                    5,
                    null,
                    new[] {new ReplaceTermSetting(2, "Hello")}
                };
            }
        }
    }
}
