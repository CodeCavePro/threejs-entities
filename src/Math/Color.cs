using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities;

[Serializable]
[JsonConverter(typeof(NewtonsoftJson.ColorIntConverter))]
[System.Text.Json.Serialization.JsonConverter(typeof(Utf8Json.ColorIntConverter))]
public class Color
{
    private readonly int integerValue;

    /// <summary>Initializes a new instance of the <see cref="Color"/> class.</summary>
    /// <param name="hex">The hexadecimal.</param>
    /// <exception cref="ArgumentException">Please provide a valid hex color representation, e.g. '0xFF00FF', '#FF00FF', 'FF00FF' - hex.</exception>
    public Color(string hex = "0xC0C0C0")
    {
        if (string.IsNullOrWhiteSpace(hex))
            throw new ArgumentException("Please provide a valid hex color representation, e.g. '0xFF00FF', '#FF00FF', 'FF00FF'", nameof(hex));

        hex = hex.Trim('#');
        integerValue = hex.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
            ? Convert.ToInt32(hex, 16)
            : int.Parse(hex, style: NumberStyles.HexNumber, CultureInfo.InvariantCulture);
    }

    /// <summary>Initializes a new instance of the <see cref="Color"/> class.</summary>
    /// <param name="red">The red.</param>
    /// <param name="green">The green.</param>
    /// <param name="blue">The blue.</param>
    /// <exception cref="ArgumentException">Red must be a number between 0 and 255 - red
    /// or
    /// Green must be a number between 0 and 255 - green
    /// or
    /// Blue must be a number between 0 and 255 - blue.</exception>
    public Color(int red, int green, int blue)
        : this($"{red:X2}{green:X2}{blue:X2}")
    {
        if (red < 0 || red > 255)
            throw new ArgumentException("Red must be a number between 0 and 255", nameof(red));
        if (green < 0 || green > 255)
            throw new ArgumentException("Green must be a number between 0 and 255", nameof(green));
        if (blue < 0 || blue > 255)
            throw new ArgumentException("Blue must be a number between 0 and 255", nameof(blue));
    }

    /// <summary>Initializes a new instance of the <see cref="Color"/> class.</summary>
    /// <param name="integerValue">The integer value.</param>
    [Newtonsoft.Json.JsonConstructor]
    [System.Text.Json.Serialization.JsonConstructor]
    internal Color(int integerValue = 0)
    {
        this.integerValue = integerValue;
    }

    /// <summary>Performs an implicit conversion from <see cref="Color"/> to <see cref="int"/>.</summary>
    /// <param name="color">The color.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator int(Color color) => color?.integerValue ?? 12632256;

    /// <summary>Performs an implicit conversion from <see cref="int"/> to <see cref="Color"/>.</summary>
    /// <param name="integerValue">The integer value.</param>
    /// <returns>The result of the conversion.</returns>
    [SuppressMessage("Usage", "CA2225:Operator overloads have named alternates", Justification = "Color to Color doesn't make any sense.")]
    public static implicit operator Color(int integerValue) => new Color(integerValue);

    /// <summary>Converts a color to <see cref="int"/>.</summary>
    /// <returns>The integer representation of a color.</returns>
    public int ToInt32() => integerValue;
}
