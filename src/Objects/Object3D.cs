using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    /// <summary>
    /// This is the base class for most objects in three.js
    /// and provides a set of properties and methods for manipulating objects in 3D space.
    /// Note that this can be used for grouping objects via the .add( object ) method
    /// which adds the object as a child, however it is better to use Group for this.
    /// </summary>
    // TODO implement: List<double> scale
    // TODO implement: List<double> position
    // TODO implement: List<double> rotation
    // TODO implement: List<double> quaternion
    [DataContract]
    public class Object3D
    {
        private readonly IDictionary<string, Object3D> children;

        /// <summary>Initializes a new instance of the <see cref="Object3D"/> class.</summary>
        /// <param name="type">The type of the object.</param>
        /// <param name="uuid">The unique identified of the object.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - type.</exception>
        [JsonConstructor]
        public Object3D(string type = nameof(Object3D), string uuid = null)
        {
            children = new Dictionary<string, Object3D>();
            UserData = new Dictionary<string, string>();
            Uuid = uuid ?? Guid.NewGuid().ToString();
            Type = string.IsNullOrWhiteSpace(type)
                ? nameof(Object3D)
                : type;
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
        /// </summary>
        /// <value>
        /// The optional name of the object.
        /// </value>
        [DataMember(Name = "name")]
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the type of the object (e.g. Object3D).
        /// </summary>
        /// <value>
        /// The type of the object.
        /// </value>
        [DataMember(Name = "type")]
        [JsonProperty("type")]
        public string Type { get; }

        /// <summary>
        /// Gets the local transform matrix.
        /// </summary>
        /// <value>
        /// The local transform matrix.
        /// </value>
        [DataMember(Name = "matrix")]
        [JsonProperty("matrix")]
        public ICollection<double> Matrix { get; private set; } = new[]
        {
            1D, 0D, 0D, 0D,
            0D, 1D, 0D, 0D,
            0D, 0D, 1D, 0D,
            0D, 0D, 0D, 1D,
        };

        /// <summary>
        /// Gets the array of object's children.
        /// </summary>
        /// <value>
        /// The array of object's children.
        /// </value>
        [DataMember(Name = nameof(children))]
        [JsonProperty(nameof(children))]
        public IReadOnlyCollection<Object3D> Children => (IReadOnlyCollection<Object3D>)children.Values;

        /// <summary>
        /// Gets or sets the ID of the geometry.
        /// </summary>
        /// <value>
        /// The ID of the geometry.
        /// </value>
        [DataMember(Name = "geometry")]
        [JsonProperty("geometry")]
        public string Geometry { get; set; }

        /// <summary>
        /// Gets or sets the name of the material.
        /// </summary>
        /// <value>
        /// The name of the material.
        /// </value>
        [DataMember(Name = "material")]
        [JsonProperty("material")]
        public string Material { get; set; }

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

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Geometry.GeometryData"/> is visible.
        /// </summary>
        /// <value>
        ///   <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "visible")]
        [JsonProperty("visible")]
        public bool Visible { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether [casts shadow].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [casts shadow]; otherwise, <c>false</c>.
        /// </value>
        [DataMember(Name = "castShadow")]
        [JsonProperty("castShadow")]
        public bool CastShadow { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether [receives shadow].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [receives shadow]; otherwise, <c>false</c>.
        /// </value>
        /// ReSharper disable once RedundantDefaultMemberInitializer
        [DataMember(Name = "receiveShadow")]
        [JsonProperty("receiveShadow")]
        public bool ReceiveShadow { get; set; } = false;

        /// <summary>Adds the child.</summary>
        /// <param name="object3D">An <see cref="Object3D"/> instance to be added as a child.</param>
        /// <exception cref="ArgumentNullException">Provide a valid Object3D instance.</exception>
        public void AddChild(Object3D object3D)
        {
            if (object3D is null)
                throw new ArgumentNullException(nameof(object3D), "Provide a valid Object3D instance.");

            if (!children.ContainsKey(object3D.Uuid))
                children.Add(object3D.Uuid, object3D);
        }

        /// <summary>Determines whether this object has a child with given UUID.</summary>
        /// <param name="uuid">The UUID of the child object.</param>
        /// <returns>
        ///   <c>true</c> if thethis object contains has a child with given UUID; otherwise, <c>false</c>.</returns>
        public bool HasChild(string uuid)
        {
            return children.ContainsKey(uuid);
        }
    }
}