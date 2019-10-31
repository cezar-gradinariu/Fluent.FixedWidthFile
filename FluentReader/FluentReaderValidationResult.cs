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

        public List<string> Errors { get; }
        public string SourceLine { get; }

        public bool HasErrors => Errors != null && Errors.Any();
    }
}