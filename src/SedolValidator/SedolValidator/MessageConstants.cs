using System;
using System.Collections.Generic;
using System.Text;

namespace SedolValidator
{
    public static class MessageConstants
    {
        public const string SEDOL_WITH_INVALID_LENGTH = "Input string was not 7-characters long";
        public const string SEDOL_WITH_INVALID_CHECKSUM = "Checksum digit does not agree with the rest of the input";
        public const string SEDOL_INVALID_CHARACTERS = "SEDOL contains invalid characters";
    }
}
