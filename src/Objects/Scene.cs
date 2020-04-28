using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    /// <summary>
    /// Scenes allow you to set up what and where is to be rendered by three.js.
    /// This is where you place objects, lights and cameras.
    /// </summary>
    /// <seealso cref="Object3D" />
    // TODO implement environment https://threejs.org/docs/#api/en/scenes/Scene.environment
    // TODO implement fog https://threejs.org/docs/#api/en/scenes/Scene.fog
    public class Scene : Object3D
    {
        /// <summary>Initializes a new instance of the <see cref="Scene"/> class.</summary>
        /// <param name="uuid">The unique identified of the object.</param>
        public Scene(string uuid)
            : base(nameof(Scene), uuid)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Scene"/> class.</summary>
        [JsonConstructor]
        private Scene()
            : this(null)
        {
        }

        /// <summary>
        /// Gets or sets a value indicating whether the renderer checks every frame if the scene and its objects needs matrix updates.
        /// When it isn't, then you have to maintain all matrices in the scene yourself.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [automatic update]; otherwise, <c>false</c>.</value>
        [DataMember(Name = "autoUpdate")]
        [JsonProperty("autoUpdate")]
        [JsonPropertyName("autoUpdate")]
        public bool AutoUpdate { get; set; } = true;

        /// <summary>
        /// Gets or sets background object.
        /// If not null, sets the background used when rendering the scene, and is always rendered first.
        /// Can be set to a Color which sets the clear color, a Texture covering the canvas, or a cubemap as a CubeTexture or WebGLCubeRenderTarget.
        /// </summary>
        /// <value>The background object.</value>
        [DataMember(Name = "background")]
        [JsonProperty("background")]
        [JsonPropertyName("background")]
        public object Background { get; set; }

        /// <summary>Gets or sets the override material.</summary>
        /// If not null, it will force everything in the scene to be rendered with that material.
        /// <value>The override material.</value>
        [DataMember(Name = "overrideMaterial")]
        [JsonProperty("overrideMaterial")]
        [JsonPropertyName("overrideMaterial")]
        public Material OverrideMaterial { get; set; }
    }
}
