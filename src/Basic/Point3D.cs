using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CodeCave.Threejs.Entities
{
    public class Point3D : IEquatable<Point3D>, IComparable<Point3D>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Point3D"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Point3D(long x, long y, long z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        [DataMember(Name = "x")]
        [JsonProperty("x")]
        public long X { get; private set; }

        [DataMember(Name = "y")]
        [JsonProperty("y")]
        public long Y { get; private set; }

        [DataMember(Name = "z")]
        [JsonProperty("z")]
        public long Z { get; private set; }

        public static bool operator ==(Point3D left, Point3D right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(Point3D left, Point3D right)
        {
            return !(left == right);
        }

        public static bool operator <(Point3D left, Point3D right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(Point3D left, Point3D right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(Point3D left, Point3D right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(Point3D left, Point3D right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other">other</paramref> parameter; otherwise, false.
        /// </returns>
        public bool Equals(Point3D other)
        {
            if (other is null)
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return X == other.X && Y == other.Y && Z == other.Z;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj.GetType() == GetType() && Equals((Point3D) obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return $@"{X},{Y},{Z}".GetHashCode();
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">a.</param>
        /// <returns></returns>
        [SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "It's more compact like this.")]
        public int CompareTo(Point3D other)
        {
            if (other is null)
                return -1;

            long deltaAxis;
            if ((deltaAxis = X - other.X) == 0)
            {
                deltaAxis = (deltaAxis = Y - other.Y) == 0
                    ? Z - other.Z
                    : deltaAxis;
            }

            if (deltaAxis == 0)
                return 0;

            return deltaAxis > 0x0 ? 1 : -1;
        }
    }
}
