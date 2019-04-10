using System.Collections.Generic;
using NSubstitute;
using TermReplacementService.Code;
using TermReplacementService.Controllers;
using TermReplacementService.Models.Responses;
using Xunit;

namespace TermReplacementService.Tests.Controllers
{
    public class TermReplacementControllerTests
    {
        [Theory]
        [ClassData(typeof(ReplaceInRange_WhenValidInput_TestData))]
        public void ReplaceInRange_WhenValidInput_ReturnsCalculatedResponse(int lowerBound, int upperBound)
        {
            // Arrange
            var mockTermsReplaced = new[] {"test"};
            var mockSummary = new Dictionary<string, int>(new[] {new KeyValuePair<string, int>("test", 1)});
            var mockOriginalNumbers = new[] { 1 };
            var expectedResponse = ReplaceInRangeResponse.Build(mockTermsReplaced,mockOriginalNumbers,mockSummary);

            var termReplacer = Substitute.For<ITermReplacer>();
            var summaryBuilder = Substitute.For<ISummaryBuilder>();
            termReplacer.ReplaceSequence(Arg.Any<int[]>()).ReturnsForAnyArgs(mockTermsReplaced);
            summaryBuilder.BuildSummary(mockTermsReplaced, Arg.Any<int[]>()).ReturnsForAnyArgs(mockSummary);
            var termReplacementController = new TermReplacementController(termReplacer, summaryBuilder);

            // Act
            var response = termReplacementController.ReplaceInRange(lowerBound, upperBound);

            // Assert
            Assert.True(expectedResponse.result == response.result && expectedResponse.summary == response.summary, "Response from ReplaceInRange action method was different than expected");
        }

        [Theory]
        [ClassData(typeof(ReplaceInRange_WhenValidInput_TestData))]
        public void ReplaceInRange_WhenValidInput_CalculatesRangeAndPassesToTermReplacer(int lowerBound, int upperBound)
        {
            // Arrange
            var termReplacer = Substitute.For<ITermReplacer>();
            var summaryBuilder = Substitute.For<ISummaryBuilder>();
            var termReplacementController = new TermReplacementController(termReplacer,summaryBuilder);

            // Act
            termReplacementController.ReplaceInRange(lowerBound, upperBound);

            // Assert
            termReplacer.Received(1).ReplaceSequence(Arg.Any<int[]>());
        }

        [Theory]
        [ClassData(typeof(ReplaceInRange_WhenValidInput_TestData))]
        public void ReplaceInRange_WhenValidInput_PassesReplacedTermsToSummaryBuilder(int lowerBound, int upperBound)
        {
            // Arrange
            var mockTermsReplaced = new[] {"Test"};
            var termReplacer = Substitute.For<ITermReplacer>();
            var summaryBuilder = Substitute.For<ISummaryBuilder>();
            termReplacer.ReplaceSequence(new[]{1,2}).ReturnsForAnyArgs(mockTermsReplaced);
            var termReplacementController = new TermReplacementController(termReplacer, summaryBuilder);

            // Act
            termReplacementController.ReplaceInRange(lowerBound, upperBound);

            // Assert
            summaryBuilder.Received(1).BuildSummary(mockTermsReplaced, Arg.Any<int[]>());
        }

        private class ReplaceInRange_WhenValidInput_TestData : TestData
        {
            public override IEnumerator<object[]> GetTestCases()
            {
                // Given bounds, expect range
                yield return new object[]
                {
                    2,
                    7
                };
            }
        }

        [Theory]
        [ClassData(typeof(ReplaceInRange_WhenArgumentsInvalid_TestData))]
        public void ReplaceInRange_WhenArgumentsInvalid_ThrowsException(int lowerBound, int upperBound)
        {
            // Arrange
            var mockTermsReplaced = new[] { "Test" };
            var termReplacer = Substitute.For<ITermReplacer>();
            var summaryBuilder = Substitute.For<ISummaryBuilder>();
            termReplacer.ReplaceSequence(new[] { 1, 2 }).ReturnsForAnyArgs(mockTermsReplaced);
            var termReplacementController = new TermReplacementController(termReplacer, summaryBuilder);

            // Act
            termReplacementController.ReplaceInRange(lowerBound, upperBound);

            // Assert
            summaryBuilder.Received(1).BuildSummary(mockTermsReplaced, Arg.Any<int[]>());
        }

        private class ReplaceInRange_WhenArgumentsInvalid_TestData : TestData
        {
            public override IEnumerator<object[]> GetTestCases()
            {
                // lower bound is greater than upperbound
                yield return new object[]
                {
                    7,
                    2,
                };
            }
        }
    }
}
