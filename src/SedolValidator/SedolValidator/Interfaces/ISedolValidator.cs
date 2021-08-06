using System;
using System.Collections.Generic;
using System.Text;

namespace SedolValidator.Interfaces
{
    public interface ISedolValidator
    {
        ISedolValidationResult ValidateSedol(string input);
    }
}
