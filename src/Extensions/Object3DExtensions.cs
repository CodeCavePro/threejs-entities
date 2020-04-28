using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CodeCave.Threejs.Entities
{
    public static class Object3DExtensions
    {
        /// <summary>Merges the specified other scene.</summary>
        /// <param name="objectScene">The object scene.</param>
        /// <param name="otherScene">The other scene.</param>
        /// <param name="newPosition">The new position of merged objects after merge.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">objectScene
        /// or
        /// otherScene.</exception>
        public static ObjectScene Merge(this ObjectScene objectScene, ObjectScene otherScene, Vector3 newPosition = null)
        {
            if (objectScene is null)
                throw new ArgumentNullException(nameof(objectScene));

            if (otherScene is null)
                throw new ArgumentNullException(nameof(otherScene));

            foreach (var geometry in otherScene.Geometries)
                objectScene.AddGeometry(geometry);

            foreach (var material in otherScene.Materials)
                objectScene.AddMaterial(material);

            if (otherScene.Object.Children.Any())
            {
                foreach (var child in otherScene.Object.Children)
                {
                    if (newPosition != null)
                        child.Position = newPosition;
                    objectScene.Object.AddChild(child);
                }
            }
            else
            {
                if (newPosition != null)
                    otherScene.Object.Position = newPosition;
                objectScene.Object.AddChild(otherScene.Object);
            }

            return objectScene;
        }

        /// <summary>Adds a simple cube (of the given dimensions and color) to the scene.</summary>
        /// <param name="objectScene">The object scene.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <param name="depth">The depth.</param>
        /// <param name="position">The position.</param>
        /// <param name="color">The color.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">objectScene.</exception>
        public static Object3D AddCube(this ObjectScene objectScene, double width, double height, double depth, Vector3 position = default, int color = 11674146)
        {
            if (objectScene is null)
                throw new ArgumentNullException(nameof(objectScene));

            var geometry = new BoxGeometry(Guid.NewGuid().ToString(), width, height, depth);
            objectScene.AddGeometry(geometry);

            var material = new MeshStandardMaterial(Guid.NewGuid().ToString())
            {
                Color = color,
            };
            objectScene.AddMaterial(material);

            var cubeObject = new Object3D("Mesh", Guid.NewGuid().ToString())
            {
                CastShadow = true,
                ReceiveShadow = true,
                GeometryUuid = geometry.Uuid,
                MaterialUuid = material.Uuid,
                Position = position,
            };
            objectScene.Object.AddChild(cubeObject);

            return cubeObject;
        }

        internal static IEnumerable<Object3D> Flatten(this IEnumerable<Object3D> collection)
        {
            foreach (var obj in collection)
            {
                if (obj.Children.Count == 0)
                    yield return obj;

                foreach (var c in obj.Children.Flatten())
                    yield return c;
            }
        }
    }
}
