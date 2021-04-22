using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    [Serializable]
    public sealed class BoxGeometry : Geometry, IEquatable<BoxGeometry>
    {
        /// <summary>Initializes a new instance of the <see cref="BoxGeometry"/> class.</summary>
        /// <param name="uuid">The UUID of this object instance.</param>
        public BoxGeometry(string uuid, double width = 1D, double height = 1D, double depth = 1D)
            : base(uuid)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        [Newtonsoft.Json.JsonConstructor]
        [System.Text.Json.Serialization.JsonConstructor]
        private BoxGeometry()
            : base(Guid.NewGuid().ToString())
        {
        }

        /// <summary>Gets the type of this object, it always equals 'BoxGeometry'.</summary>
        /// <value>The 'BoxGeometry' type.</value>
        [DataMember(Name = "type")]
        [JsonProperty("type")]
        [JsonPropertyName("type")]

        public override string Type => nameof(BoxGeometry);

        /// <summary>
        /// Gets or sets width — Width; that is, the length of the edges parallel to the X axis. Optional; defaults to 1.
        /// </summary>
        /// <value>The width.</value>
        [DataMember(Name = "width")]
        [JsonProperty("width")]
        [JsonPropertyName("width")]
        public double Width { get; set; }

        /// <summary>
        /// Gets or sets height — Height; that is, the length of the edges parallel to the Y axis.Optional; defaults to 1.
        /// </summary>
        /// <value>The height.</value>
        [DataMember(Name = "height")]
        [JsonProperty("height")]
        [JsonPropertyName("height")]
        public double Height { get; set; }

        /// <summary>
        /// Gets or sets depth — Depth; that is, the length of the edges parallel to the Z axis.Optional; defaults to 1.
        /// </summary>
        /// <value>The depth.</value>
        [DataMember(Name = "depth")]
        [JsonProperty("depth")]
        [JsonPropertyName("depth")]
        public double Depth { get; set; }

        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public override GeometryData Data => null;

        public override bool Equals(object obj) => obj is BoxGeometry geometry && Equals(geometry);

        public bool Equals(BoxGeometry other) => Uuid.Equals(other?.Uuid, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode()
        {
            return 2083305506 + EqualityComparer<string>.Default.GetHashCode(Uuid);
        }
    }
}
