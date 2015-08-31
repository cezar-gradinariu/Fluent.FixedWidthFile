using System.Collections.Generic;
using System.Linq;

namespace FluentReader
{
    public class LineError
    {
        public string SourceLine { get; set; }
        public string Message { get; set; }
        public List<SegmentError> SegmentErrors { get; set; }

        public bool HasErrors
        {
            get { return SegmentErrors != null && SegmentErrors.Any(); }
        }
    }
}