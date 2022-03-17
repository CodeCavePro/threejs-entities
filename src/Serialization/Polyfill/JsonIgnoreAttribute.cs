#if NET45 || NETSTANDARD2_0_OR_GREATER

namespace System.Text.Json.Serialization
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsonIgnoreAttribute : Attribute
    {
        public JsonIgnoreAttribute()
        {
            // does nothing on .NET Framework 4.5
        }
    }
}

#endif
