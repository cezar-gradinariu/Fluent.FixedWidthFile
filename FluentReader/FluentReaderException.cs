using System;
using System.Runtime.Serialization;

namespace FluentReader
{
    [Serializable]
    public class FluentReaderException : Exception
    {
        public FluentReaderException()
        {
        }

        public FluentReaderException(string message) : base(message)
        {
        }

        public FluentReaderException(string message, Exception inner) : base(message, inner)
        {
        }

        protected FluentReaderException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

        public uint StartIndex { get; set; }
        public uint StringLength { get; set; }
    }
}