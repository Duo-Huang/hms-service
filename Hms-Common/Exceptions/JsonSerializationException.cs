namespace Hms_Common.Exceptions;

public class JsonSerializationException(string message, Exception innerException) : Exception(message, innerException)
{
    public JsonSerializationException(Exception innerException) : this("Json serialization failure", innerException)
    {
    }
}