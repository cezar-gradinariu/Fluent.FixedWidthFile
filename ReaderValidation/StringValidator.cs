using System;
using System.Collections.Generic;
using System.Linq;

namespace ReaderValidation
{
    public class StringValidator
    {
        private readonly LineError _error;
        private readonly List<SegmentError> _errors;
        private readonly string _source;
        private int _currentIndex;

        public StringValidator(string source)
        {
            _source = source;
            _currentIndex = 0;
            _errors = new List<SegmentError>();
            _error = new LineError {SegmentErrors = _errors, SourceLine = source};
        }

        public Segment ForNext(uint count, string segmentName)
        {
            var temp = _source ?? string.Empty;
            var nextIndex = _currentIndex + (int) count;
            if (nextIndex > (temp?.Length ?? 0))
            {
                temp = temp.PadRight(nextIndex, ' ');
            }

            var segmentValue = temp.Substring(_currentIndex, (int) count);
            _currentIndex = nextIndex;
            return new Segment(this, segmentValue, segmentName);
        }

        public StringValidator CheckLength(uint expectedLength)
        {
            if (_source == null || _source.Length != expectedLength)
            {
                _error.Message = string.Format("The line is expected to have exactly {0} characters", expectedLength);
            }

            return this;
        }

        public StringValidator CheckLengthRange(uint minLength, uint maxLength)
        {
            if (_source == null || _source.Length < minLength || _source.Length > maxLength)
            {
                _error.Message = string.Format("The line is expected to have between {0} and {1} characters", minLength,
                    maxLength);
            }

            return this;
        }

        public LineError Read()
        {
            return _error;
        }

        public class Segment
        {
            private readonly string _segmentName;
            private readonly StringValidator _validator;

            private readonly string _value;

            public Segment(StringValidator v, string value, string segmentName)
            {
                _value = value;
                _segmentName = segmentName;
                _validator = v;
            }

            public StringValidator ExpectThat(params Func<Is, SegmentError>[] validations)
            {
                _validator._errors.AddRange(ExecuteValidations(validations));
                return _validator;
            }

            private IEnumerable<SegmentError> ExecuteValidations(IEnumerable<Func<Is, SegmentError>> validations)
            {
                return validations
                    .Select(v => v(new Is(_value, _segmentName)))
                    .Where(error => error != null)
                    .ToList();
            }
        }
    }
}