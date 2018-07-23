using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vueling.Common.Layer
{
    /// <summary>
    /// Customized exception
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class VuelingException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VuelingException"/> class.
        /// </summary>
        public VuelingException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VuelingException"/> class.
        /// </summary>
        /// <param name="message">Mensaje que describe el error.</param>
        public VuelingException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="VuelingException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public VuelingException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
