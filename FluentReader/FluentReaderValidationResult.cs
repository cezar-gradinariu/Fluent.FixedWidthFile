using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentReader
{
    public class FluentReaderValidationResult
    {
        public FluentReaderValidationResult(List<string> errors, string sourceLine)
        {
            if (errors == null || !errors.Any())
            {
                throw new ArgumentNullException("errors");
            }
            Errors = errors;
            SourceLine = sourceLine;
        }

        public List<string> Errors { get; private set; }
        public string SourceLine { get; private set; }

        public bool HasErrors
        {
            get { return Errors != null && Errors.Any(); }
        }
    }
}