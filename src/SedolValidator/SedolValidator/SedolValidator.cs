using SedolValidator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SedolValidator
{
    public class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string input)
        {
            var sedol = new Sedol(input);

            var validationResult = new SedolValidationResult(input, false, false, null);

            if (!sedol.HasValidLength)
            {
                validationResult.ValidationDetails = MessageConstants.SEDOL_WITH_INVALID_LENGTH;

            }
            else if (!sedol.IsAlphaNumeric)
            {
                validationResult.ValidationDetails = MessageConstants.SEDOL_INVALID_CHARACTERS;
            }
            else
            {
                validationResult.IsUserDefined = sedol.IsUserDefined;
                validationResult.IsValidSedol = sedol.HasValidCheckDigit;

                validationResult.ValidationDetails = !validationResult.IsValidSedol ? MessageConstants.SEDOL_WITH_INVALID_CHECKSUM : null;
            }

            return validationResult;
        }
    }
}
