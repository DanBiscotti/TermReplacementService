using System.Collections.Generic;
using TermReplacementService.Code;
using Xunit;

namespace TermReplacementService.Tests.Code
{
    public class SummaryBuilderTests
    {
        [Theory]
        [ClassData(typeof(BuildSummaryTestData))]
        public void BuildSummary_GivenStringArray_ReturnsSummary(string[] termsReplaced, int[] originalNumbers,
            Dictionary<string, int> expectedSummary)
        {
            // Arrange
            var summaryBuilder = new SummaryBuilder();

            // Act
            var resultSummary = summaryBuilder.BuildSummary(termsReplaced, originalNumbers);

            // Assert
            Assert.Equal(resultSummary, expectedSummary);
        }

        private class BuildSummaryTestData : TestData
        {
            public override IEnumerator<object[]> GetTestCases()
            {
                // Given string array and original numbers, expected dictionary
                yield return new object[]
                {
                    new[]{null, "Banana", null, null},
                    new[]{5,3,9,7},
                    new Dictionary<string,int>(
                        new[]
                        {
                            new KeyValuePair<string, int>("Banana", 1),
                            new KeyValuePair<string, int>("Integer", 3)
                        }
                    )
                };
            }
        }
    }
}
