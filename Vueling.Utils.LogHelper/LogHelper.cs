using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Utils.LogHelper
{
    /// <summary>
    /// Logger method
    /// </summary>
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }
    }
}
