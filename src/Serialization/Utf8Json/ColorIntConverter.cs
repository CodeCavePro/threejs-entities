namespace CodeCave.Threejs.Entities.Utf8Json;

public class ColorIntConverter : System.Text.Json.Serialization.JsonConverter<Color>
{
    public override Color Read(
        ref System.Text.Json.Utf8JsonReader reader,
        System.Type typeToConvert,
        System.Text.Json.JsonSerializerOptions options)
    {
        return new Color(reader.GetInt32());
    }

    public override void Write(
        System.Text.Json.Utf8JsonWriter writer,
        Color value,
        System.Text.Json.JsonSerializerOptions options)
    {
        if (writer is null)
            throw new System.ArgumentNullException(nameof(writer));

        var integerValue = (int)value;
        writer.WriteNumberValue(integerValue);
    }
}
