using SedolValidator.Interfaces;

namespace SedolValidator
{
    public class SedolValidationResult : ISedolValidationResult
    {
        public SedolValidationResult()
        {
        }

        public SedolValidationResult(string inputString,
            bool isValidSedol,
            bool isUserDefined,
            string validationDetails)
        {
            InputString = inputString;
            IsValidSedol = isValidSedol;
            IsUserDefined = isUserDefined;
            ValidationDetails = validationDetails;
        }

        public string InputString { get; set; }

        public bool IsValidSedol { get; set; }

        public bool IsUserDefined { get; set; }

        public string ValidationDetails { get; set; }
    }
}
