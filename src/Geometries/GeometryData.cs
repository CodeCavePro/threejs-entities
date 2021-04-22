using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    // TODO implement morphTargets[]
    // TODO implement morphNormals[]
    [Serializable]
    [DataContract]
    public class GeometryData
    {
        [Newtonsoft.Json.JsonConstructor]
        [System.Text.Json.Serialization.JsonConstructor]
        internal GeometryData()
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether [casts shadow].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [casts shadow]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "castShadow")]
        [JsonProperty("castShadow")]
        [JsonPropertyName("castShadow")]
        public bool CastShadow { get; set; } = true;

        /// <summary>
        /// Gets or sets the array of vertex colors, matching number and order of vertices.
        /// </summary>
        /// <value>
        /// The array of vertex colors, matching number and order of vertices.
        /// </value>
        [DataMember(Name = "colors")]
        [JsonProperty("colors")]
        [JsonPropertyName("colors")]
        public ICollection<int> Colors { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets a value indicating whether [is double sided].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is double sided]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "doubleSided")]
        [JsonProperty("doubleSided")]
        [JsonPropertyName("doubleSided")]
        public bool DoubleSided { get; set; } = true;

        /// <summary>
        /// Gets or sets the array of faces.
        /// The array of faces describe how each vertex in the model is connected to form faces.
        /// Additionally it holds information about face and vertex normals and colors.
        /// </summary>
        /// <value>
        /// The array of faces.
        /// </value>
        [DataMember(Name = "faces")]
        [JsonProperty("faces")]
        [JsonPropertyName("faces")]
        public List<int> Faces { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the normals.
        /// </summary>
        /// <value>
        /// The normals.
        /// </value>
        [DataMember(Name = "normals")]
        [JsonProperty("normals")]
        [JsonPropertyName("normals")]
        public ICollection<double> Normals { get; set; } = new List<double>();

        /// <summary>
        /// Gets or sets a value indicating whether [receives shadow].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [receives shadow]; otherwise, <c>false</c>.
        /// </value>
        /// ReSharper disable once RedundantDefaultMemberInitializer
        [DataMember(Name = "receiveShadow")]
        [JsonProperty("receiveShadow")]
        [JsonPropertyName("receiveShadow")]
        public bool ReceiveShadow { get; set; } = false;

        /// <summary>
        /// Gets or sets the scale of the geometry data.
        /// Scaling is typically done as a one time operation but not during the render loop.
        /// </summary>
        /// <value>
        /// The scale of the geometry data.
        /// </value>
        [DataMember(Name = "scale")]
        [JsonProperty("scale")]
        [JsonPropertyName("scale")]
        public double Scale { get; set; } = 1.0D;

        /// <summary>
        /// Gets or sets the array of face UV layers, used for mapping textures onto the geometry.
        /// Each UV layer is an array of UVs matching the order and number of vertices in faces.
        /// </summary>
        /// <value>
        /// The array of face UV layers, used for mapping textures onto the geometry.
        /// </value>
        [DataMember(Name = "uvs")]
        [JsonProperty("uvs")]
        [JsonPropertyName("uvs")]
        public List<double> UVs { get; set; } = new List<double>();

        /// <summary>
        /// Gets or sets the array of vertices (in millimeters).
        /// </summary>
        /// <value>
        /// The array of vertices holds the position of every vertex in the model.
        /// </value>
        [DataMember(Name = "vertices")]
        [JsonProperty("vertices")]
        [JsonPropertyName("vertices")]
        public ICollection<double> Vertices { get; set; } = new List<double>();

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="GeometryData"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "visible")]
        [JsonProperty("visible")]
        [JsonPropertyName("visible")]
        public bool Visible { get; set; } = true;
    }
}
