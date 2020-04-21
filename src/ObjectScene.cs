using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    /// <summary>
    /// Implements some of the specs of Three.js JSON Object/Scene format.
    /// More info here: https://github.com/mrdoob/three.js/wiki/JSON-Object-Scene-format-4.
    /// </summary>
    [DataContract]
    public sealed class ObjectScene
    {
        private static readonly JsonSerializerSettings JsonDefaultSetting = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            Formatting = Formatting.Indented,
        };

        private readonly IDictionary<string, Geometry> geometries;
        private readonly IDictionary<string, Material> materials;

        [DataMember(Name = nameof(metadata))]
        [JsonProperty(nameof(metadata))]
        private readonly ObjectMetadata metadata;

        /// <summary>Initializes a new instance of the <see cref="ObjectScene"/> class.</summary>
        /// <param name="generator">The generator, which created the file..</param>
        /// <param name="uuid">The UUID.</param>
        /// <exception cref="ArgumentException">Must be a valid uninque id. - uuid.</exception>
        /// <exception cref="ArgumentNullException">metadata.</exception>
        public ObjectScene(string generator, string uuid)
            : this()
        {
            Object = new Scene(uuid ?? throw new ArgumentException("Must be a valid uninque id.", nameof(uuid)));
            metadata = new ObjectMetadata(generator);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectScene"/> class.
        /// </summary>
        [JsonConstructor]
        internal ObjectScene()
        {
            Object = new Scene(Guid.NewGuid().ToString());
            metadata = new ObjectMetadata();
            UserData = new Dictionary<string, string>();
            geometries = new Dictionary<string, Geometry>();
            materials = new Dictionary<string, Material>();
        }

        [DataMember(Name = nameof(geometries))]
        [JsonProperty(nameof(geometries))]
        public IReadOnlyCollection<Geometry> Geometries => (IReadOnlyCollection<Geometry>)geometries.Values;

        [DataMember(Name = nameof(materials))]
        [JsonProperty(nameof(materials))]
        public IReadOnlyCollection<Material> Materials => (IReadOnlyCollection<Material>)materials.Values;

        [DataMember(Name = "object")]
        [JsonProperty("object")]
        [SuppressMessage("Naming", "CA1720:Identifier contains type name", Justification = "Doesn't really matter")]
        public Object3D Object { get; internal set; }

        /// <summary>
        /// Gets or sets the user data.
        /// An object that can be used to store custom data about the Object3D. It should not hold references to functions as these will not be cloned.
        /// </summary>
        /// <value>
        /// The user data.
        /// </value>
        [DataMember(Name = "userData")]
        [JsonProperty("userData")]
        public IDictionary<string, string> UserData { get; set; }

        /// <summary>Adds the geometry.</summary>
        /// <param name="geometry">The geometry.</param>
        /// <exception cref="ArgumentNullException">geometry.</exception>
        public void AddGeometry(Geometry geometry)
        {
            if (geometry is null)
                throw new ArgumentNullException(nameof(geometry));

            if (!geometries.ContainsKey(geometry.Uuid))
                geometries.Add(geometry.Uuid, geometry);
        }

        /// <summary>Adds the material.</summary>
        /// <param name="material">The material.</param>
        /// <exception cref="ArgumentNullException">material.</exception>
        public void AddMaterial(Material material)
        {
            if (material is null)
                throw new ArgumentNullException(nameof(material));

            if (!materials.ContainsKey(material.Uuid))
                materials.Add(material.Uuid, material);
        }

        /// <summary>Determines whether the specified UUID has material.</summary>
        /// <param name="uuid">The UUID.</param>
        /// <returns>
        ///   <c>true</c> if the specified UUID has material; otherwise, <c>false</c>.</returns>
        public bool HasMaterial(string uuid)
        {
            return materials.ContainsKey(uuid);
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public override string ToString() => ToString(JsonDefaultSetting);

        /// <summary>Converts to string.</summary>
        /// <param name="settings">The settings.</param>
        /// <returns>A <see cref="string"/> that represents this instance.</returns>
        public string ToString(JsonSerializerSettings settings) => JsonConvert.SerializeObject(this, settings);

        [DataContract]
        private class ObjectMetadata
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ObjectMetadata"/> class.
            /// </summary>
            /// <param name="generator">The generator, which created the file.</param>
            /// <exception cref="ArgumentNullException">version.</exception>
            /// <exception cref="ArgumentException">
            /// Value cannot be null or whitespace. - generator
            /// or
            /// Value cannot be null or whitespace. - type.
            /// </exception>
            public ObjectMetadata(string generator)
            {
                if (string.IsNullOrWhiteSpace(generator))
                    throw new ArgumentException("Value cannot be null or whitespace.", nameof(generator));
                Generator = generator;
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ObjectMetadata"/> class.
            /// </summary>
            [JsonConstructor]
            internal ObjectMetadata()
            {
            }

            /// <summary>
            /// Gets the generator, which created the file.
            /// </summary>
            /// <value>
            /// The generator, which created the file.
            /// </value>
            [DataMember(Name = "generator")]
            [JsonProperty("generator")]
            public string Generator { get; }

            /// <summary>
            /// Gets the type of the file.
            /// </summary>
            /// <value>
            /// The type of the file.
            /// </value>
            [DataMember(Name = "type")]
            [JsonProperty("type")]
            public string Type { get; } = nameof(Object);

            /// <summary>
            /// Gets the version of the file.
            /// </summary>
            /// <value>
            /// The version of the file.
            /// </value>
            [DataMember(Name = "version")]
            [JsonProperty("version")]
            public string Version { get; } = "4.3";
        }
    }
}
