namespace OptMobile.Retailer.Helpers;

public class ApiException : Exception
{
    public ApiException(string message, Exception innerException = null)
        : base(message, innerException)
    {
    }
}

public class NetworkException : ApiException
{
    public NetworkException(string message, Exception innerException = null)
        : base(message, innerException)
    {
    }
}

public class SerializationException : ApiException
{
    public SerializationException(string message, Exception innerException = null)
        : base(message, innerException)
    {
    }
}
