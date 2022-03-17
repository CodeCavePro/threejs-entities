using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities.NewtonsoftJson
{
    [SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "This class is a Json.NET converter set via prop attributes")]
    internal class ColorIntConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (!int.TryParse(reader?.Value?.ToString(), out var integerValue))
                throw new NotImplementedException();

            return new Color(integerValue);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is not Color)
                throw new NotImplementedException();

            writer.WriteValue(((Color)value).ToInt32());
        }
    }
}
