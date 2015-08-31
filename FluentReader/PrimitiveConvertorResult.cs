namespace FluentReader
{
    internal class PrimitiveConvertorResult<TU>
    {
        public PrimitiveConvertorResult(TU result, bool hasErrors, string valueToConvert)
        {
            Result = result;
            HasErrors = hasErrors;
            ValueToConvert = valueToConvert;
        }

        public TU Result { get; set; }
        public bool HasErrors { get; set; }
        public string ValueToConvert { get; set; }
    }
}