namespace Validation
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }
}