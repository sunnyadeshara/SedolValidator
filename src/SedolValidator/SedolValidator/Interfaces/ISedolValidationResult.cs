using System;
using System.Collections.Generic;
using System.Text;

namespace SedolValidator.Interfaces
{
    public interface ISedolValidationResult
    {
        string InputString { get; }
        bool IsValidSedol { get; }
        bool IsUserDefined { get; }
        string ValidationDetails { get; }
    }
}
