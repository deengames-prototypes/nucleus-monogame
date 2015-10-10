using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ninject;
using Nucleus.Core;

namespace Nucleus.Ecs.Components
{
    public class ImageComponent : Component, IDisposable
    {
        private string fileName;
        private Texture2D texture;
        private SpriteBatch spriteBatch;

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
        }

        public void Draw()
        {
            this.spriteBatch.Draw(this.texture, this.Entity.Get<TwoDComponent>().Position);
        }

        public void Dispose()
        {
            this.texture.Dispose();
        }
    }
}

