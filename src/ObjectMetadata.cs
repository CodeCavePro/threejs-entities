using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    [DataContract]
    public class ObjectMetadata
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
        [JsonPropertyName("generator")]
        public string Generator { get; private set; }

        /// <summary>
        /// Gets the type of the file.
        /// </summary>
        /// <value>
        /// The type of the file.
        /// </value>
        [DataMember(Name = "type")]
        [JsonProperty("type")]
        [JsonPropertyName("type")]
        public string Type { get; private set; } = nameof(Object);

        /// <summary>
        /// Gets the version of the file.
        /// </summary>
        /// <value>
        /// The version of the file.
        /// </value>
        [DataMember(Name = "version")]
        [JsonProperty("version")]
        [JsonPropertyName("version")]
        public string Version { get; private set; } = "4.3";
    }
}
