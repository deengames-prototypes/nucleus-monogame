using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ninject;
using Nucleus.Core;

namespace Nucleus.Ecs.Components
{
    public class ImageComponent : Component, IDisposable
    {
        protected string fileName;
        protected Texture2D texture;
        protected SpriteBatch spriteBatch;
        protected Vector2 scale = Vector2.One;
        protected Vector2 origin = Vector2.Zero;

        protected const float PI = (float)Math.PI;

        public ImageComponent(string fileName)
        {
            this.fileName = fileName;
            if (CommonGame.Instance.Initialized)
            {
                this.Initialize();
            }

            this.spriteBatch = CommonGame.Instance.Kernel.Get<SpriteBatch>();
        }

        public void Initialize()
        {
            this.texture = CommonGame.Instance.Content.Load<Texture2D>(this.fileName);
            this.origin = new Vector2(this.texture.Width / 2, this.texture.Height / 2);
        }

        public virtual void Draw()
        {
            var pos = this.Entity.Get<TwoDComponent>();
            this.spriteBatch.Draw(this.texture, pos.Position, null, null, 
                origin, pos.Rotation * PI / 180f, scale, null, 0, pos.Z);
        }

        public void Dispose()
        {
            this.texture.Dispose();
        }
    }
}

