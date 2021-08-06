using SedolValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SedolValidator.Tests
{
    public class UnitTests
    {
        ISedolValidator sedolValidator = null;
        public UnitTests()
        {
            sedolValidator = new SedolValidator();
        }

        [Theory]
        [InlineData(null, false, false, "Input string was not 7-characters long")]
        [InlineData("", false, false, "Input string was not 7-characters long")]
        [InlineData("12", false, false, "Input string was not 7-characters long")]
        [InlineData("123456789", false, false, "Input string was not 7-characters long")]
        [InlineData("1234567", false, false, "Checksum digit does not agree with the rest of the input")]
        [InlineData("0709954", true, false, null)]
        [InlineData("B0YBKJ7", true, false, null)]
        [InlineData("9123451", false, true, "Checksum digit does not agree with the rest of the input")]
        [InlineData("9ABCDE8", false, true, "Checksum digit does not agree with the rest of the input")]
        [InlineData("9123_51", false, false, "SEDOL contains invalid characters")]
        [InlineData("VA.CDE8", false, false, "SEDOL contains invalid characters")]
        [InlineData("9123458", true, true, null)]
        [InlineData("9ABCDE1", true, true, null)]
        public void SedolTest(string input, bool isValidSedol, bool isUserDefined, string validationMessage)
        {
            ISedolValidationResult result = sedolValidator.ValidateSedol(input);
            Assert.Equal(result.IsValidSedol, isValidSedol);
            Assert.Equal(result.IsUserDefined, isUserDefined);
            Assert.Equal(result.ValidationDetails?.ToLowerInvariant(), validationMessage?.ToLowerInvariant());
        }
    }
}