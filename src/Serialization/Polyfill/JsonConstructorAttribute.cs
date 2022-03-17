#if NET45 || NETSTANDARD2_0_OR_GREATER

namespace System.Text.Json.Serialization
{
    [AttributeUsage(AttributeTargets.Constructor)]

    public sealed class JsonConstructorAttribute : Attribute
    {
    }
}

#endif
