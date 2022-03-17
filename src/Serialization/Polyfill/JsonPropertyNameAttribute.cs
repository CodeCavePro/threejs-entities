#if NET45 || NETSTANDARD2_0_OR_GREATER

namespace System.Text.Json.Serialization
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsonPropertyNameAttribute : Attribute
    {
        public JsonPropertyNameAttribute(string name)
        {
            // does nothing on .NET Framework 4.5
            name?.ToString();
        }
    }
}

#endif
