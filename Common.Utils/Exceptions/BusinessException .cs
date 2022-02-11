using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utils.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException() : base()
        {
        }

        //Por medio de la execpcion puedo mandar un mensaje
        public BusinessException(string message) : base(message)
        {
        }

        //También puedo enviar la excepcion
        public BusinessException(string message, Exception inner) : base(message, inner)
        {
        }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected BusinessException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context)
        { }
    }
}
