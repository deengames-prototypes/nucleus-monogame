using System;
using Nucleus.Ecs;
using Microsoft.Xna.Framework;

namespace Nucleus
{
    public class TwoDComponent : Component
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        /// <summary>
        /// The angle of rotation, in degrees
        /// </summary>
        /// <value>The rotation.</value>
        public int Rotation { get; set; }

        public Vector2 Position { get { return new Vector2(this.X, this.Y); } }

        public TwoDComponent(int x = 0, int y = 0, int z = 0)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Rotation = 0;
        }
    }
}

