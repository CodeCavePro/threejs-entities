using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    /// <summary>
    /// A material for shiny surfaces with specular highlights.
    /// The material uses a non-physically based Blinn-Phong model for calculating reflectance.
    /// Unlike the Lambertian model used in the MeshLambertMaterial this can simulate shiny surfaces with specular highlights (such as varnished wood).
    /// Shading is calculated using a Phong shading model.
    /// This calculates shading per pixel (i.e. in the fragment shader, AKA pixel shader)
    /// which gives more accurate results than the Gouraud model used by MeshLambertMaterial,
    /// at the cost of some performance. The MeshStandardMaterial and MeshPhysicalMaterial also use this shading model.
    /// Performance will generally be greater when using this material over the MeshStandardMaterial or MeshPhysicalMaterial, at the cost of some graphical accuracy.
    /// </summary>
    /// ReSharper disable once InheritdocConsiderUsage
    [Serializable]
    [DataContract]
    public sealed class MeshPhongMaterial : Material
    {
        public MeshPhongMaterial(string uuid)
            : base(uuid)
        {
        }

        [Newtonsoft.Json.JsonConstructor]
        [System.Text.Json.Serialization.JsonConstructor]
        private MeshPhongMaterial()
            : base(Guid.NewGuid().ToString())
        {
        }

        /// <summary>
        /// Gets the type of the material.
        /// </summary>
        [DataMember(Name = "type")]
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public override string Type => nameof(MeshPhongMaterial);

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
        public Color Color { get; set; } = 16777215;

        /// <summary>
        /// Gets or sets the ambient.
        /// </summary>
        /// <value>
        /// The ambient.
        /// </value>
        [DataMember(Name = "ambient")]
        [JsonProperty("ambient")]
        [JsonPropertyName("ambient")]
        [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJson.ColorIntConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(Utf8Json.ColorIntConverter))]

        public Color Ambient { get; set; } = 16777215;

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
        public Color Emissive { get; set; } = 1;

        /// <summary>
        /// Gets or sets the specular color of the material. Default is a Color set to 0x111111 (very dark grey).
        /// This defines how shiny the material is and the color of its shine.
        /// </summary>
        /// <value>
        /// The specular color of the material.
        /// </value>
        [DataMember(Name = "specular")]
        [JsonProperty("specular")]
        [JsonPropertyName("specular")]
        [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftJson.ColorIntConverter))]
        [System.Text.Json.Serialization.JsonConverter(typeof(Utf8Json.ColorIntConverter))]
        public Color Specular { get; set; } = 1118481;

        /// <summary>
        /// Gets or sets how shiny the <see cref="Color"/> highlight is
        /// A higher value gives a sharper highlight. Default is 30.
        /// </summary>
        /// <value>
        /// The shininess.
        /// </value>
        [DataMember(Name = "shininess")]
        [JsonProperty("shininess")]
        [JsonPropertyName("shininess")]
        public int Shininess { get; set; } = 30;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Material"/> is a wire-frame.
        /// Render geometry as wire-frame. Default is false (i.e. render as flat polygons).
        /// </summary>
        /// <value>
        ///   <c>true</c> if wire-frame; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "wireframe")]
        [JsonProperty("wireframe")]
        [JsonPropertyName("wireframe")]
        public bool Wireframe { get; set; }

        public override bool Equals(object obj) => Equals(obj as MeshPhongMaterial);

        public override int GetHashCode() => base.GetHashCode();
    }
}
