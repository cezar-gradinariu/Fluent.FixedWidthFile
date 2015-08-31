using System.Collections.Generic;

namespace FluentReader
{
    public class FluentReaderResult<T>
    {
        public FluentReaderResult()
        {
            LineError = new LineError {SegmentErrors = new List<SegmentError>()};
        }

        public T Result { get; set; }
        public LineError LineError { get; set; }
    }
}