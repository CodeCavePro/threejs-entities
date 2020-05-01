namespace CodeCave.Threejs.Entities.Utf8Json
{
    public class PolymorphicJsonConverter<TObject>
#if NET45
    {
    }
#else
        : System.Text.Json.Serialization.JsonConverter<TObject>
    {
        // TODO: do something about System.Text.Json ignoring read-only properties by default (private, protected, internal etc)
        public override TObject Read(ref System.Text.Json.Utf8JsonReader reader, System.Type typeToConvert, System.Text.Json.JsonSerializerOptions options)
        {
            using var doc = System.Text.Json.JsonDocument.ParseValue(ref reader);
            if (doc.RootElement.TryGetProperty("type", out var typeDiscriminator))
            {
                var type = System.Type.GetType($"{nameof(CodeCave)}.{nameof(Threejs)}.{nameof(Entities)}.{typeDiscriminator.GetString()}");
                if (type != typeToConvert)
                {
                    var @object = System.Text.Json.JsonSerializer.Deserialize(doc.RootElement.GetRawText(), type, options);
                    return (TObject)@object;
                }
            }

            // HACK: avoid using System.Text.Json, because it will loop till stack overflow exception
            // I will burn in hell for this + it ignores JsonSerializerOptions options
            return Newtonsoft.Json.JsonConvert.DeserializeObject<TObject>(doc.RootElement.GetRawText());
        }

        public override void Write(System.Text.Json.Utf8JsonWriter writer, TObject value, System.Text.Json.JsonSerializerOptions options)
        {
            if (writer is null)
                throw new System.ArgumentNullException(nameof(writer));

            // HACK: avoid using System.Text.Json, because it will loop till stack overflow exception
            // I will burn in hell for this + it ignores JsonSerializerOptions options
            var rawJson = Newtonsoft.Json.JsonConvert.SerializeObject(value); // System.Text.Json.JsonSerializer.Serialize(value, value?.GetType() ?? typeof(object), options);
            using var document = System.Text.Json.JsonDocument.Parse(rawJson);
            document.RootElement.WriteTo(writer);
        }
    }
#endif
}
