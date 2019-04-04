using System;
using System.Runtime.Serialization;

namespace UnGranViaje
{
    [Serializable]
    internal class MotorException : Exception
    {
        public MotorException()
        {
        }

        public MotorException(string message) : base(message)
        {
        }

        public MotorException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MotorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}