using System;
using Nucleus.Ecs.Components;
using Microsoft.Xna.Framework;

namespace Nucleus
{
    public class SpriteSheetComponent : ImageComponent
    {
        public int TileWidth { get; private set; }
        public int TileHeight { get; private set; }

        public int CurrentFrame
        {
            get
            {
                return this.currentFrame; 
            }
            set
            {
                this.currentFrame = value % this.totalFrames;
                this.rectangle = new Rectangle(
                    CurrentFrame * this.TileWidth % this.texture.Width,
                    this.TileHeight * (CurrentFrame * this.TileWidth / this.texture.Width), 
                    this.TileWidth, this.TileHeight);
            }
        }

        private int currentFrame = 0;
        private Rectangle rectangle;
        private int totalFrames = 0;

        public SpriteSheetComponent(string fileName, int tileWidth, int tileHeight) : base(fileName)
        {
            // TODO: throw if we're bigger than the image
            this.TileWidth = tileWidth;
            this.TileHeight = tileHeight;
            this.totalFrames = (this.texture.Width / tileWidth) * (this.texture.Height / tileHeight);
            this.CurrentFrame = 0; // set rectangle
        }

        public override void Draw()
        {
            var pos = this.Entity.Get<TwoDComponent>();
            this.spriteBatch.Draw(this.texture, pos.Position, null, this.rectangle, 
                origin, pos.Rotation * PI / 180f, scale, null, 0, pos.Z);
        }
    }
}

