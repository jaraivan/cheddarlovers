using System;
using System.Runtime.Serialization;

[Serializable]
internal class BaulLlenoException : Exception
{
    public BaulLlenoException()
    {
    }

    public BaulLlenoException(string message) : base(message)
    {
    }

    public BaulLlenoException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected BaulLlenoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}