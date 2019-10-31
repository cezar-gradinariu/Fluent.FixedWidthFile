using System;
using System.Linq.Expressions;
using System.Reflection;

namespace FluentReader
{
    public class FluentReader<T> where T : class, new()
    {
        private readonly T _result;
        private readonly SourceHandler _sourceHandler;

        public FluentReader(string source)
            : this(source, new T())
        {
        }

        private FluentReader(string source, T result)
        {
            _result = result;
            _sourceHandler = new SourceHandler(source);
            ReaderResult = new FluentReaderResult<T>();
        }

        private FluentReaderResult<T> ReaderResult { get; }

        public FluentReader<T> Set<TU>(Expression<Func<T, TU>> property, Action<FieldReader<TU>> action,
            string useExactFormat = null)
        {
            var fieldReader = new FieldReader<TU>(_sourceHandler);
            action(fieldReader);
            var result = fieldReader.Read(useExactFormat);
            if (result.HasErrors)
            {
                ReaderResult.LineError.SegmentErrors.Add(new SegmentError(result.ValueToConvert, string.Format(
                    "Could not convert {0} to type {1}", result.ValueToConvert, typeof(TU).Name), property.Name));
                return this;
            }

            SetPropertyValue(property, result.Result);
            return this;
        }

        public FluentReader<T> Skip(uint skip)
        {
            _sourceHandler.Skip(skip);
            return this;
        }

        public FluentReaderResult<T> Read()
        {
            if (ReaderResult.LineError.HasErrors)
            {
                ReaderResult.LineError.SourceLine = _sourceHandler.Original;
            }
            else
            {
                ReaderResult.Result = _result;
                ReaderResult.LineError = null;
            }

            return ReaderResult;
        }

        private void SetPropertyValue<TU>(Expression<Func<T, TU>> memberLambda, TU value)
        {
            var memberSelectorExpression = memberLambda.Body as MemberExpression;
            if (memberSelectorExpression == null)
            {
                return;
            }

            var property = memberSelectorExpression.Member as PropertyInfo;
            if (property != null)
            {
                property.SetValue(_result, value, null);
            }
        }

        public class FieldReader<TU>
        {
            private readonly SourceHandler _sourceHandler;
            private string _temporary;

            internal FieldReader(SourceHandler sourceHandler)
            {
                _sourceHandler = sourceHandler;
            }

            public FieldReader<TU> Skip(uint skip)
            {
                _sourceHandler.Skip(skip);
                return this;
            }

            public FieldReader<TU> Take(uint take)
            {
                _temporary = _sourceHandler.Take(take);
                return this;
            }

            public FieldReader<TU> ToLowerCase()
            {
                _temporary = _temporary.ToLowerInvariant();
                return this;
            }

            public FieldReader<TU> TrimEnd(char @char = ' ')
            {
                _temporary = _temporary.TrimEnd(@char);
                return this;
            }

            public FieldReader<TU> TrimStart(char @char = ' ')
            {
                _temporary = _temporary.TrimStart(@char);
                return this;
            }

            public FieldReader<TU> Trim(char @char = ' ')
            {
                _temporary = _temporary.Trim(@char);
                return this;
            }

            internal PrimitiveConvertorResult<TU> Read(string exactFormat = null)
            {
                var convertor = new PrimitiveConvertor<TU>();
                return convertor.Convert(_temporary, exactFormat);
            }
        }


        internal class SourceHandler
        {
            public SourceHandler(string original)
            {
                Original = original;
                CurrentIndex = 0;
            }

            public string Original { get; set; }
            private uint CurrentIndex { get; set; }

            public void Skip(uint skip)
            {
                CurrentIndex += skip;
            }

            public string Take(uint take)
            {
                var nextIndex = CurrentIndex + take;
                var result = Original.Length <= nextIndex
                    ? Original.PadRight((int) nextIndex, ' ').Substring((int) CurrentIndex, (int) take)
                    : Original.Substring((int) CurrentIndex, (int) take);
                CurrentIndex = nextIndex;
                return result;
            }
        }
    }
}