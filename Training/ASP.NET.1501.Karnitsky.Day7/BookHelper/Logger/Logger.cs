using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace BookHelper
{
    public class Logger : ILogger
    {
        private readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

        public void WriteError(string errorMessage, string source, string stackTrace)
        {
            logger.Error(errorMessage, source, stackTrace);
        }

        public void WriteWarning(string warningMessage)
        {
            logger.Debug(warningMessage);
        }
    }
}
