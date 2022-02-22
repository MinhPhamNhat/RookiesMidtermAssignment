namespace RookiesFashion.APIService.Ex
{
    public class ValidationError
    {
        //  [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        public object Value { get; }
        public string ErrorMessage { get; }
        public ValidationError(string field, object value, string message)
        {
            Field = !string.IsNullOrEmpty(field) ? field : "null";
            Value = value;
            ErrorMessage = message;
        }
    }
}