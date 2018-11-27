using System;
using System.Runtime.Serialization;

[Serializable]
internal class NoTienesEseItemEnNingunSlotException : Exception
{
    public NoTienesEseItemEnNingunSlotException()
    {
    }

    public NoTienesEseItemEnNingunSlotException(string message) : base(message)
    {
    }

    public NoTienesEseItemEnNingunSlotException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected NoTienesEseItemEnNingunSlotException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}