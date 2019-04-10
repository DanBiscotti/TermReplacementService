using System.Collections.Generic;

using TermReplacementService.Models.Responses;
using Xunit;

namespace TermReplacementService.Tests.Models.Responses
{
    public class ReplaceInRangeResponseTests
    {
        [Theory]
        [ClassData(typeof(BuildTestData))]
        public void Build_ReturnsCorrectResponse(string[] termsReplaced, int[] originalNumbers, string expectedResult)
        {
            // Arrange
            var mockSummary = new Dictionary<string, int>();

            // Act
            var replaceInRangeResponse = ReplaceInRangeResponse.Build(termsReplaced,originalNumbers,mockSummary);

            // Assert
            Assert.Equal(expectedResult,replaceInRangeResponse.result);
        }

        private class BuildTestData : TestData
        {
            public override IEnumerator<object[]> GetTestCases()
            {
                // String array gets joined with replacing nulls
                yield return new object[]
                {
                    new[] {null,"Basketball",null},
                    new[] {1,4,5},
                    "1 Basketball 5"
                };
            }
        }
    }
}
