using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ninject;

namespace Nucleus
{
    public class SpriteComponent : IDisposable
    {
        private string fileName;
        private Texture2D texture;
        private SpriteBatch spriteBatch;

        public SpriteComponent(string fileName)
        {
            this.fileName = fileName;
            if (CommonGame.Instance.Initialized)
            {
                this.Initialize();
            }

            this.spriteBatch = CommonGame.Instance.SpriteBatch;
        }

        public void Initialize()
        {
            this.texture = CommonGame.Instance.Content.Load<Texture2D>(this.fileName);
        }

        public void Draw() {
            this.spriteBatch.Draw(this.texture, Vector2.Zero);
        }

        public void Dispose()
        {
            this.texture.Dispose();
        }
    }
}

