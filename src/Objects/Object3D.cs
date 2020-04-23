using System;
using System.Collections.Generic;
using System.Linq;
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
    [DataContract]
    public class Object3D : IEquatable<Object3D>, IEqualityComparer<Object3D>
    {
        /// <summary>
        /// When this is set, it calculates the matrix of position, (rotation or quaternion) and scale every frame and also recalculates the matrixWorld property.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [matrix automatic update]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "matrixAutoUpdate")]
        [JsonProperty("matrixAutoUpdate")]
        public const bool MatrixAutoUpdate = false; // HACK: since we calculate Matrix from Position, Scale, Rotation etc, we don't auto-update it

        private HashSet<Object3D> children;

        /// <summary>Initializes a new instance of the <see cref="Object3D"/> class.</summary>
        /// <param name="type">The type of the object.</param>
        /// <param name="uuid">The unique identified of the object.</param>
        /// <param name="id">The identified of the object.</param>
        /// <exception cref="ArgumentException">Value cannot be null or whitespace. - type.</exception>
        [JsonConstructor]
        public Object3D(string type = nameof(Object3D), string uuid = null, long? id = null)
        {
            children = new HashSet<Object3D>();

            Id = id;
            UserData = new Dictionary<string, string>();
            Uuid = uuid ?? Guid.NewGuid().ToString();
            Type = string.IsNullOrWhiteSpace(type)
                ? nameof(Object3D)
                : type;
        }

        /// <summary>Gets the identifier.</summary>
        /// <value>The identifier.</value>
        [DataMember(Name = "id")]
        [JsonProperty("id")]
        public long? Id { get; private set; }

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
        public ICollection<double> Matrix => new[]
        {
            Scale?.X ?? 1D, 0D, 0D, 0D, // TODO implement rotation, quaternion
            0D, Scale?.Y ?? 1D, 0D, 0D,
            0D, 0D, Scale?.Z ?? 0D, 0D,
            Position?.X ?? 0D, Position?.X ?? 0D, Position?.X ?? 0D, 1D,
        };

        /// <summary>
        /// Gets the array of object's children.
        /// </summary>
        /// <value>
        /// The array of object's children.
        /// </value>
        [DataMember(Name = nameof(children))]
        [JsonProperty(nameof(children))]
        public IReadOnlyCollection<Object3D> Children
        {
            get => children as IReadOnlyCollection<Object3D>;
            private set => children = new HashSet<Object3D>(value);
        }

        /// <summary>
        /// Gets or sets the ID of the geometry.
        /// </summary>
        /// <value>
        /// The ID of the geometry.
        /// </value>
        [DataMember(Name = "geometry")]
        [JsonProperty("geometry")]
        public string GeometryUuid { get; set; }

        /// <summary>
        /// Gets or sets the name of the material.
        /// </summary>
        /// <value>
        /// The name of the material.
        /// </value>
        [DataMember(Name = "material")]
        [JsonProperty("material")]
        public string MaterialUuid { get; set; }

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
        /// Gets or sets a value indicating whether this <see cref="Object3D"/> is visible.
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

        /// <summary
        /// >Gets or sets <see cref="Vector3"/> representing the object's local position.
        /// Default is (0, 0, 0).
        /// </summary>
        /// <value>The position of this object.</value>
        [DataMember(Name = "position")]
        [JsonProperty("position")]
        public Vector3 Position { get; set; } = new Vector3(0, 0, 0);

        /// <summary>Gets or sets the object's local scale.</summary>
        /// <value>The object's local scale.</value>
        [DataMember(Name = "scale")]
        [JsonProperty("scale")]
        public Vector3 Scale { get; set; } = new Vector3(1, 1, 1);

        /// <summary>Gets or sets the orientation of the result.</summary>
        /// <value>This is used by the lookAt method, for example, to determine the orientation of the result.</value>
        [DataMember(Name = "up")]
        [JsonProperty("up")]
        public Vector3 Up { get; set; } = new Vector3(0, 1, 0);

        /// <summary>Adds the child.</summary>
        /// <param name="object3D">An <see cref="Object3D"/> instance to be added as a child.</param>
        /// <exception cref="ArgumentNullException">Provide a valid Object3D instance.</exception>
        public void AddChild(Object3D object3D)
        {
            if (object3D is null)
                throw new ArgumentNullException(nameof(object3D), "Provide a valid Object3D instance.");

            if (!children.Contains(object3D))
                children.Add(object3D);
        }

        /// <summary>Determines whether this object has a child with given UUID.</summary>
        /// <param name="uuid">The UUID of the child object.</param>
        /// <returns>
        ///   <c>true</c> if thethis object contains has a child with given UUID; otherwise, <c>false</c>.</returns>
        public bool HasChild(string uuid) => children.Any(c => c.Uuid.Equals(uuid, StringComparison.OrdinalIgnoreCase));

        /// <summary>Determines whether the specified child object has child.</summary>
        /// <param name="childObject">The child object.</param>
        /// <returns>
        ///   <c>true</c> if the specified child object has child; otherwise, <c>false</c>.</returns>
        public bool HasChild(Object3D childObject)
        {
            return children.Contains(childObject);
        }

        public override bool Equals(object obj) => obj is Object3D other && Equals(other);

        public bool Equals(Object3D other) => Uuid.Equals(other?.Uuid, StringComparison.OrdinalIgnoreCase);

        public override int GetHashCode()
        {
            return 2083305506 + EqualityComparer<string>.Default.GetHashCode(Uuid);
        }

        public bool Equals(Object3D x, Object3D y)
        {
            return x?.Equals(y) ?? false;
        }

        public int GetHashCode(Object3D obj)
        {
            if (obj is null)
                throw new ArgumentNullException(nameof(obj));

            return obj.GetHashCode();
        }
    }
}
