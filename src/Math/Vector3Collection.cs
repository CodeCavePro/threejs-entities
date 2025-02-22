using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace CodeCave.Threejs.Entities;

[Serializable]
public sealed class Vector3Collection : IEnumerable<Vector3>
{
    private readonly IDictionary<Vector3, int> vertices = new Dictionary<Vector3, int>();

    /// <summary>
    ///     Return the index of the given vertex,
    ///     adding a new entry if required.
    /// </summary>
    /// <param name="p">TODO: describe p parameter on AddVertex.</param>
    [SuppressMessage("Major Code Smell", "S1121:Assignments should not be made from within sub-expressions", Justification = "It's just supposed to be like that")]
    public int AddVertex(Vector3 p) => vertices.ContainsKey(p)
            ? vertices[p]
            : vertices[p] = vertices.Count;

    /// <summary>
    /// Returns an enumerator that iterates through the collection.
    /// </summary>
    /// <returns>
    /// An enumerator that can be used to iterate through the collection.
    /// </returns>
    public IEnumerator<Vector3> GetEnumerator()
    {
        return vertices.Keys.GetEnumerator();
    }

    /// <summary>
    /// Returns an enumerator that iterates through a collection.
    /// </summary>
    /// <returns>
    /// An <see cref="IEnumerator"></see> object that can be used to iterate through the collection.
    /// </returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
