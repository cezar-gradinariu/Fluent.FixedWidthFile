using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Validation
{
    public class Validation<T> where T : class
    {
        private readonly T _toValidate;

        public Validation(T toValidate)
        {
            _toValidate = toValidate;
            ValidationResults = new List<ValidationResult>();
        }

        private List<ValidationResult> ValidationResults { get; }

        public Validation<T> IsRequired(Expression<Func<T, string>> e)
        {
            var message = string.Format("{0} is required.", e.PropertyName());
            return CustomRule(e, p => !string.IsNullOrWhiteSpace(p), message);
        }

        public Validation<T> IsRequired<TU>(Expression<Func<T, TU?>> e) where TU : struct
        {
            var message = string.Format("{0} is required.", e.PropertyName());
            return CustomRule(e, p => p != null, message);
        }

        public Validation<T> HasMaxLength(Expression<Func<T, string>> e, uint length)
        {
            var message =
                string.Format("{0} must have maximum {1} characters.", e.PropertyName(), length);
            return CustomRule(e, p => p == null || p.Length <= length, message);
        }

        public Validation<T> CustomRule<TU>(Expression<Func<T, TU>> e, Predicate<TU> rule, string message)
        {
            var value = e.PropertyValue(_toValidate);
            if (!rule(value))
            {
                AddError(e.PropertyName(), message);
            }

            return this;
        }

        public Validation<T> IsEqualTo(Expression<Func<T, string>> e, string expectedValue)
        {
            var message = string.Format("{0} is expected to be equal to '{1}'.",
                e.PropertyName(), expectedValue);
            return CustomRule(e, p => p != null && p.Equals(expectedValue), message);
        }

        public Validation<T> StartsWith(Expression<Func<T, string>> e, string expectedValue)
        {
            var message = string.Format("{0} is expected to start with '{1}'.",
                e.PropertyName(), expectedValue);
            return CustomRule(e,
                p =>
                    !string.IsNullOrWhiteSpace(p) && !string.IsNullOrWhiteSpace(expectedValue) &&
                    p.StartsWith(expectedValue), message);
        }

        public ValidationSummary<T> ReadResults()
        {
            return new ValidationSummary<T> {ValidatedObject = _toValidate, ValidationResults = ValidationResults};
        }

        private void AddError(string propertyName, string errorMessage)
        {
            ValidationResults.Add(new ValidationResult
            {
                IsValid = false,
                PropertyName = propertyName,
                ErrorMessage = errorMessage
            });
        }
    }
}