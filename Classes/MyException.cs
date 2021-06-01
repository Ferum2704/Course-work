using System;

namespace LibraryWallet
{
    public class OperationPerformingException : Exception
    {
        public OperationPerformingException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
    public class FileEmptyException : Exception
    {
        public FileEmptyException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
}
