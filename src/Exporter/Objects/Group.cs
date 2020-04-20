namespace CodeCave.Threejs.Entities
{
    /// <summary>This is almost identical to an Object3D. Its purpose is to make working with groups of objects syntactically clearer.</summary>
    /// <seealso cref="Object3D" />
    public class Group : Object3D
    {
        public Group(string uuid = null)
            : base(nameof(Group), uuid)
        {
        }
    }
}
