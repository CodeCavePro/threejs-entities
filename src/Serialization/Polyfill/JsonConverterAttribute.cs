#if NET45 || NETSTANDARD2_0_OR_GREATER

namespace System.Text.Json.Serialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public sealed class JsonConverterAttribute : Attribute
    {
        public JsonConverterAttribute(Type type)
        {
            // does nothing on .NET Framework 4.5
            type?.ToString();
        }
    }
}

#endif
