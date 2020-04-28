#if NET45

namespace System.Text.Json.Serialization
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class JsonIgnore : Attribute
    {
        public JsonIgnore()
        {
            // does nothing on .NET Framework 4.5
        }
    }
}

#endif
