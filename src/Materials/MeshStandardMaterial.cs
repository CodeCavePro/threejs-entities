using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities;

[Serializable]
public class MeshStandardMaterial : Material
{
    public MeshStandardMaterial(string uuid)
        : base(uuid)
    {
    }

    [Newtonsoft.Json.JsonConstructor]
    [System.Text.Json.Serialization.JsonConstructor]
    private MeshStandardMaterial()
        : base(Guid.NewGuid().ToString())
    {
    }

    /// <summary>
    /// Gets the type of the material.
    /// </summary>
    [DataMember(Name = "type")]
    [JsonProperty("type")]
    [JsonPropertyName("type")]
    public override string Type => nameof(MeshStandardMaterial);

    /// <summary>
    /// Gets or sets the color of the material, by default set to white (0xffffff).
    /// </summary>
    /// <value>
    /// The color of the material.
    /// </value>
    [DataMember(Name = "color")]
    [JsonProperty("color")]
    [JsonPropertyName("color")]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJson.ColorIntConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(Utf8Json.ColorIntConverter))]
    public Color Color { get; set; } = 11674146;

    /// <summary>
    /// Gets or sets how rough the material appears.
    /// 0.0 means a smooth mirror reflection, 1.0 means fully diffuse.</summary>
    /// <value>The roughness.</value>
    [DataMember(Name = "roughness")]
    [JsonProperty("roughness")]
    [JsonPropertyName("roughness")]
    public double Roughness { get; set; }

    /// <summary>
    /// Gets or sets how much the material is like a metal.
    /// Non-metallic materials such as wood or stone use 0.0, metallic use 1.0, with nothing (usually) in between.
    /// </summary>
    /// <value>The metalness.</value>
    [DataMember(Name = "metalness")]
    [JsonProperty("metalness")]
    [JsonPropertyName("metalness")]
    public double Metalness { get; set; } = 0.0;

    /// <summary>
    /// Gets or sets the emissive (light) color of the material,
    /// essentially a solid color unaffected by other lighting. Default is black.
    /// </summary>
    /// <value>
    /// The emissive (light) color of the material.
    /// </value>
    [DataMember(Name = "emissive")]
    [JsonProperty("emissive")]
    [JsonPropertyName("emissive")]
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJson.ColorIntConverter))]
    [System.Text.Json.Serialization.JsonConverter(typeof(Utf8Json.ColorIntConverter))]
    public Color Emissive { get; set; } = 2434361;
}
