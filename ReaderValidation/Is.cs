using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace ReaderValidation
{
    public class Is
    {
        private readonly string _segmentName;
        private readonly string _value;

        public Is(string value, string segmentName)
        {
            _value = value;
            _segmentName = segmentName;
        }

        public static Func<Is, SegmentError> Integer
        {
            get
            {
                int temp;
                return @is => int.TryParse(@is._value, out temp)
                    ? null
                    : new SegmentError(@is._value,
                        string.Format("'{0}' segment should be in integer format!", @is._segmentName),
                        @is._segmentName);
            }
        }

        public static Func<Is, SegmentError> Long
        {
            get
            {
                long temp;
                return @is => long.TryParse(@is._value, out temp)
                    ? null
                    : new SegmentError(@is._value,
                        string.Format("'{0}' segment should be in long format!", @is._segmentName),
                        @is._segmentName);
            }
        }

        public static Func<Is, SegmentError> Decimal
        {
            get
            {
                decimal temp;
                return @is => decimal.TryParse(@is._value, out temp)
                    ? null
                    : new SegmentError(@is._value,
                        string.Format("'{0}' segment should be in decimal format!", @is._segmentName),
                        @is._segmentName);
            }
        }


        public static Func<Is, SegmentError> NotNull
        {
            get
            {
                return @is => @is._value == null
                    ? new SegmentError(@is._value, string.Format("'{0}' segment is required!", @is._segmentName),
                        @is._segmentName)
                    : null;
            }
        }

        public static Func<Is, SegmentError> Valued
        {
            get
            {
                return @is => string.IsNullOrWhiteSpace(@is._value)
                    ? new SegmentError(@is._value,
                        string.Format("'{0}' segment is required and must not contain only whitespaces!",
                            @is._segmentName), @is._segmentName)
                    : null;
            }
        }

        public static Func<Is, SegmentError> Optional
        {
            get { return @is => null; }
        }

        public static Func<Is, SegmentError> EqualTo(string value)
        {
            return @is => @is._value != null && @is._value.Equals(value)
                ? null
                : new SegmentError(@is._value,
                    string.Format("'{0}' segment is required to be equal with '{1}'", @is._segmentName, value),
                    @is._segmentName);
        }

        public static Func<Is, SegmentError> DateTime(string exactFormat)
        {
            return @is =>
            {
                DateTime temp;
                return @is._value == null ||
                       !System.DateTime.TryParseExact(@is._value.Trim(), exactFormat, CultureInfo.InvariantCulture,
                           DateTimeStyles.None, out temp)
                    ? new SegmentError(@is._value,
                        string.Format("'{0}' is expected be in date time format of '{1}'.", @is._segmentName,
                            exactFormat),
                        @is._segmentName)
                    : null;
            };
        }

        public static Func<Is, SegmentError> OneOf(params string[] values)
        {
            if (values == null)
            {
                return @is => null;
            }

            return @is => @is._value != null && values.ToList().Contains(@is._value)
                ? null
                : new SegmentError(@is._value,
                    string.Format("'{0}' segment is required to be one of the next values '{1}'", @is._segmentName,
                        string.Join(", ", values)),
                    @is._segmentName);
        }

        public static Func<Is, SegmentError> Matching(string regex)
        {
            if (string.IsNullOrWhiteSpace(regex))
            {
                return @is => new SegmentError(@is._value, "Regex expression must be provided!", @is._segmentName);
            }

            return @is => @is._value != null && Regex.IsMatch(@is._value, regex)
                ? null
                : new SegmentError(@is._value,
                    string.Format("'{0}' segment is required to match this regex expression '{1}'.", @is._segmentName,
                        regex), @is._segmentName);
        }
    }
}