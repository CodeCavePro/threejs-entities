using System;
using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    [SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "This class is a Json.NET converter set via prop attributes")]
    internal class ColorIntConverter : JsonConverter<Color>
    {
        public override Color ReadJson(JsonReader reader, Type objectType, Color existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (!int.TryParse(reader?.Value?.ToString(), out var integerValue))
                throw new NotImplementedException();

            return new Color(integerValue);
        }

        public override void WriteJson(JsonWriter writer, Color value, JsonSerializer serializer)
        {
            var integerValue = (int)value;
            writer.WriteValue(integerValue);
        }
    }
}
