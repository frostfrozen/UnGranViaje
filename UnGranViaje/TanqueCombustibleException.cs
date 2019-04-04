using System;
using System.Runtime.Serialization;

namespace UnGranViaje
{
    [Serializable]
    internal class TanqueCombustibleException : Exception
    {
        public TanqueCombustibleException()
        {
        }

        public TanqueCombustibleException(string message) : base(message)
        {
        }

        public TanqueCombustibleException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TanqueCombustibleException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}