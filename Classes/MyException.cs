using System;

namespace Classes
{
    public class OperationPerformingException : Exception
    {
        public OperationPerformingException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
