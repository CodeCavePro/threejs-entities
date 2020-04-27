using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using JsonSubTypes;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    /// <summary>
    /// Abstract base class for materials.
    /// Materials describe the appearance of objects.
    /// They are defined in a (mostly) renderer-independent way
    /// so you don't have to rewrite materials if you decide to use a different renderer.
    /// The following properties and methods are inherited by all other material types
    /// (although they may have different defaults).
    /// </summary>
    [Serializable]
    [DataContract]
    [JsonConverter(typeof(JsonSubtypes), nameof(Type))]
    [JsonSubtypes.KnownSubType(typeof(MeshPhongMaterial), nameof(MeshPhongMaterial))]
    [JsonSubtypes.KnownSubType(typeof(MeshStandardMaterial), nameof(MeshStandardMaterial))]
    public class Material : IEquatable<Material>, IEqualityComparer<Material>
    {
        /// <summary>Initializes a new instance of the <see cref="Material"/> class.</summary>
        /// <param name="uuid">The UUID of this object instance.</param>
        protected Material(string uuid)
        {
            Uuid = uuid ?? Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Gets the UUID of this object instance.
        /// </summary>
        /// <value>
        /// The UUID. This gets automatically assigned and shouldn't be edited.
        /// </value>
        [DataMember(Name = "uuid")]
        [JsonProperty("uuid")]
        public string Uuid { get; private set; }

        /// <summary>
        /// Gets or sets the optional name of the object (doesn't need to be unique).
        /// Default is an empty string.
        /// </summary>
        /// <value>
        /// The optional name of the object.
        /// </value>
        [DataMember(Name = "name")]
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the opacity of the material.
        /// Float in the range of 0.0 - 1.0 indicating how transparent the material is.
        /// A value of 0.0 indicates fully transparent, 1.0 is fully opaque.
        /// If the material's transparent property is not set to true,
        /// the material will remain fully opaque and this value will only affect its color.
        /// </summary>
        /// <value>
        /// The opacity of the material.
        /// </value>
        [DataMember(Name = "opacity")]
        [JsonProperty("opacity")]
        public double Opacity { get; set; } = 1;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Material"/> is transparent.
        /// Defines whether this material is transparent.
        /// This has an effect on rendering as transparent objects need special treatment and are rendered after non-transparent objects.
        /// When set to true, the extent to which the material is transparent is controlled by setting it's opacity property.
        /// </summary>
        /// <value>
        ///   <c>true</c> if transparent; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "transparent")]
        [JsonProperty("transparent")]
        public bool Transparent { get; set; }

        /// <summary>
        /// Gets the type of the material.
        /// </summary>
        [DataMember(Name = "type")]
        [JsonProperty("type")]
        public virtual string Type => nameof(Material);

        public override bool Equals(object obj) => obj is Material other && Equals(other);

        public bool Equals(Material other) => Uuid.Equals(other?.Uuid, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode()
        {
            return 2083305506 + EqualityComparer<string>.Default.GetHashCode(Uuid);
        }

        public bool Equals(Material x, Material y)
        {
            return x?.Equals(y) ?? false;
        }

        public int GetHashCode(Material obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj.GetHashCode();
        }
    }
}
