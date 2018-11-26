using System;
using System.Runtime.Serialization;

[Serializable]
internal class InventarioLlenoException : Exception
{
    public InventarioLlenoException()
    {
    }

    public InventarioLlenoException(string message) : base(message)
    {
    }

    public InventarioLlenoException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected InventarioLlenoException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}