namespace Hms.Common.Exceptions;

public class JsonDeserializationException(string message, Exception innerException) : Exception(message, innerException)
{
    public JsonDeserializationException(Exception innerException) : this("Json deserialization failure", innerException)
    {
    }
}