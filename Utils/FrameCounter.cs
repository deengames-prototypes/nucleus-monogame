using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Nucleus.Core;
using Ninject;

namespace Nucleus.Utils
{
    public class FrameCounter
    {
        public FrameCounter()
        {
        }

        private int framesSeen = 0;
        private DateTime lastUpdate = DateTime.Now;
        private int fps;

        public void Draw()
        {
            framesSeen += 1;
            var elapsed = (DateTime.Now - lastUpdate).TotalSeconds;

            if (elapsed > 1)
            {
                fps = (int)Math.Round(framesSeen / elapsed);
                framesSeen = 0;
                this.lastUpdate = DateTime.Now;
            }

            var font = CommonGame.Instance.Kernel.Get<SpriteFont>();
            var spriteBatch = CommonGame.Instance.Kernel.Get<SpriteBatch>();
            var fpsDisplay = string.Format("{0} FPS", fps);
            spriteBatch.DrawString(font, fpsDisplay, new Vector2(1, 1), Color.White);

        }
    }
}

