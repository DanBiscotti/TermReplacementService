using System;
using System.Collections.Generic;
using TermReplacementService.Models.Configuration;
using Xunit;

namespace TermReplacementService.Tests.Models.Configuration
{
    public class ReplaceTermSettingTests
    {
        [Theory]
        [ClassData(typeof(Constructor_WhenArgumentsInvalid_ThrowsException_TestData))]
        public void Constructor_WhenArgumentsAreInvalid_ThrowsException(int multipleOf, string replaceWith)
        {
            // Arrange

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new ReplaceTermSetting(multipleOf,replaceWith));
        }

        private class Constructor_WhenArgumentsInvalid_ThrowsException_TestData : TestData
        {
            public override IEnumerator<object[]> GetTestCases()
            {
                // replaceWith is null
                yield return new object[]
                {
                    2,
                    null
                };
                // replaceWith is empty string
                yield return new object[]
                {
                    2,
                    ""
                };
                // multipleOf is negative
                yield return new object[]
                {
                    -1,
                    "test"
                };
                // multipleOf is 0
                yield return new object[]
                {
                    0,
                    "test"
                };
            }
        }
    }
}
