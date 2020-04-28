#if NET45

namespace System.Text.Json.Serialization
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public sealed class JsonConverterAttribute : Attribute
    {
        public JsonConverterAttribute(Type type)
        {
            // does nothing on .NET Framework 4.5
        }
    }
}

#endif
