using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SedolValidator
{
    public class Sedol
    {
        private readonly string _value;
        private readonly List<int> _weights;

        private const int VALID_SEDOL_LENGTH = 7;
        private const int CHECK_DIGIT_INDEX = 6;
        private const int CHAR_INDEX_FOR_USER_DEFINED_SEDOL = 0;
        private const char FIRST_CHAR_FOR_USER_DEFINED_SEDOL = '9';

        public Sedol(string input)
        {
            _value = input;
            _weights = new List<int> { 1, 3, 1, 7, 3, 9 };
        }

        public bool HasValidLength
        {
            get
            {
                return !String.IsNullOrWhiteSpace(_value) && _value.Length == VALID_SEDOL_LENGTH;
            }
        }

        public bool IsAlphaNumeric
        {
            get { return Regex.IsMatch(_value, "^[a-zA-Z0-9]*$"); }
        }

        public bool IsUserDefined
        {
            get { return _value[CHAR_INDEX_FOR_USER_DEFINED_SEDOL] == FIRST_CHAR_FOR_USER_DEFINED_SEDOL; }
        }

        public char CheckDigit
        {
            get
            {
                var codes = _value.Take(VALID_SEDOL_LENGTH - 1).Select(GetCodeValue).ToList();
                var weightedSum = _weights.Zip(codes, (w, c) => w * c).Sum();
                return Convert.ToChar(((10 - (weightedSum % 10)) % 10).ToString(CultureInfo.InvariantCulture));
            }
        }

        public bool HasValidCheckDigit
        {
            get { return _value[CHECK_DIGIT_INDEX] == CheckDigit; }
        }

        private static int GetCodeValue(char input)
        {
            if (Char.IsLetter(input))
                return Char.ToUpper(input) - 55;
            return input - 48;
        }
    }
}