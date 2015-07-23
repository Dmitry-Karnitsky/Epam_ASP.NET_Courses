using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHelper
{
    public interface ILogger
    {
        void WriteWarning(string message);
        void WriteError(string errorMessage, string source, string stackTrace);
    }
}
