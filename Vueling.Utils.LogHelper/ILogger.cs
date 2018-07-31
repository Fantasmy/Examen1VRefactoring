using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Utils.LogHelper
{
    public interface ILogger
    {
        #region Methods
        void Debug(Object message);
        void Error(Object message);
        #endregion
    }
}
