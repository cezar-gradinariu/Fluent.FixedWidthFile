using System.Collections.Generic;
using System.Linq;

namespace Validation
{
    public class ValidationSummary<T>
    {
        public bool IsValid
        {
            get { return ValidationResults == null || ValidationResults.All(p => p.IsValid); }
        }

        public List<ValidationResult> ValidationResults { get; set; }
        public T ValidatedObject { get; set; }
    }
}