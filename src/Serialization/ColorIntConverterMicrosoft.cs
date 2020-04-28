namespace CodeCave.Threejs.Entities
{
    public class ColorIntConverterMicrosoft
#if NET45
    { }
#else
        : System.Text.Json.Serialization.JsonConverter<Color>
    {
        public override Color Read(
            ref System.Text.Json.Utf8JsonReader reader,
            System.Type typeToConvert,
            System.Text.Json.JsonSerializerOptions options)
        {
            if (!int.TryParse(reader.GetString(), out var integerValue))
                throw new System.NotImplementedException();

            return new Color(integerValue);
        }

        public override void Write(
            System.Text.Json.Utf8JsonWriter writer,
            Color value,
            System.Text.Json.JsonSerializerOptions options)
        {
            if (writer is null)
                throw new System.ArgumentNullException(nameof(writer));

            var integerValue = (int)value;
            writer.WriteStringValue(integerValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }
    }
#endif
}
