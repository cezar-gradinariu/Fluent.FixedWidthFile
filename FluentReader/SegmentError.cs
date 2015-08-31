namespace FluentReader
{
    public class SegmentError
    {
        public SegmentError(string source, string message, string segmentName)
        {
            Source = source;
            Message = message;
            SegmentName = segmentName;
        }

        public string SegmentName { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
    }
}