using System;
using System.Text;

namespace FluentWriter
{
    public class FluentWriter
    {
        private readonly StringBuilder _builder;

        public FluentWriter()
        {
            _builder = new StringBuilder();
        }

        public FluentWriter Reset()
        {
            _builder.Clear();
            return this;
        }

        public string Read()
        {
            return _builder.ToString();
        }

        public FluentWriter NewLine()
        {
            _builder.AppendLine();
            return this;
        }

        public FluentWriter NewField(string value)
        {
            return NewField(value, null);
        }

        public FluentWriter NewField(decimal? value, string format = "N2")
        {
            var formatted = value?.ToString(format);
            return NewField(formatted, null);
        }

        public FluentWriter NewField(decimal? value, Action<FieldWriter> func, string format = "N2")
        {
            var formatted = value?.ToString(format);
            return NewField(formatted, func);
        }

        public FluentWriter NewField(DateTime? value, string format = "dd/MM/yy")
        {
            var formatted = value?.ToString(format);
            return NewField(formatted, null);
        }

        public FluentWriter NewField(DateTime? value, Action<FieldWriter> func, string format = "dd/MM/yy")
        {
            var formatted = value?.ToString(format);
            return NewField(formatted, func);
        }

        public FluentWriter NewField(string value, Action<FieldWriter> func)
        {
            if (func == null)
            {
                _builder.Append(value ?? string.Empty);
                return this;
            }

            var fieldWriter = new FieldWriter(this, _builder, value);
            func(fieldWriter);
            fieldWriter.Close();
            return this;
        }

        public FluentWriter FillWith(char fillingChar, uint count)
        {
            _builder.Append(new string(fillingChar, (int) count));
            return this;
        }

        public FieldWriter NewField()
        {
            var field = new FieldWriter(this, _builder, string.Empty);
            return field;
        }

        public class FieldWriter
        {
            private readonly StringBuilder _builder;
            private readonly FluentWriter _writer;
            private string _field;

            internal FieldWriter(FluentWriter writer, StringBuilder builder, string value)
            {
                _writer = writer;
                _builder = builder;
                _field = value ?? string.Empty;
            }

            public FieldWriter RightJustify(int totalWidth, char paddingChar = ' ')
            {
                _field = _field.PadLeft(totalWidth, paddingChar);
                return this;
            }

            public FieldWriter LeftJustify(int totalWidth, char paddingChar = ' ')
            {
                _field = _field.PadRight(totalWidth, paddingChar);
                return this;
            }

            public FieldWriter ToUpper()
            {
                _field = _field.ToUpperInvariant();
                return this;
            }

            public FieldWriter ToLower()
            {
                _field = _field.ToLowerInvariant();
                return this;
            }

            public FieldWriter TakeLast(uint count)
            {
                if (_field.Length > count)
                {
                    _field = _field.Substring(_field.Length - (int) count, (int) count);
                }

                return this;
            }

            public FieldWriter TakeFirst(uint count)
            {
                if (_field.Length > count)
                {
                    _field = _field.Substring(0, (int) count);
                }

                return this;
            }

            public FieldWriter TrimStart(params char[] trimChars)
            {
                _field = _field.TrimStart(trimChars);
                return this;
            }

            public FieldWriter TrimEnd(params char[] trimChars)
            {
                _field = _field.TrimEnd(trimChars);
                return this;
            }

            public FieldWriter Trim(params char[] trimChars)
            {
                _field = _field.Trim(trimChars);
                return this;
            }

            public FieldWriter Remove(params char[] toRemove)
            {
                if (toRemove == null || toRemove.Length == 0)
                {
                    return this;
                }

                foreach (var remove in toRemove) _field = _field.Replace(remove + "", "");
                return this;
            }

            public FieldWriter Append(string value)
            {
                _field += value ?? string.Empty;
                return this;
            }

            public FieldWriter Map(Func<string, string> map)
            {
                _field = map(_field);
                return this;
            }

            public FluentWriter Close()
            {
                _builder.Append(_field);
                return _writer;
            }

            public string Read()
            {
                return _field;
            }
        }
    }
}