#if NET45

namespace System.Text.Json.Serialization
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsonPropertyNameAttribute : Attribute
    {
        public JsonPropertyNameAttribute(string name)
        {
            // does nothing on .NET Framework 4.5
        }
    }
}

#endif
