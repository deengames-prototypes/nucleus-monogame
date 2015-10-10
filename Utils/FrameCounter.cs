using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Nucleus.Utils
{
    public class FrameCounter
    {
        public FrameCounter()
        {
        }

        public long TotalFrames { get; private set; }
        public float TotalSeconds { get; private set; }
        public float AverageFramesPerSecond { get; private set; }
        public float CurrentFramesPerSecond { get; private set; }

        public const int MAXIMUM_SAMPLES = 100;

        private Queue<float> sampleBuffer = new Queue<float>();

        public bool Update(float deltaTime)
        {
            CurrentFramesPerSecond = 1.0f / deltaTime;

            sampleBuffer.Enqueue(CurrentFramesPerSecond);

            if (sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                sampleBuffer.Dequeue();
                AverageFramesPerSecond = sampleBuffer.Average(i => i);
            } 
            else
            {
                AverageFramesPerSecond = CurrentFramesPerSecond;
            }

            TotalFrames++;
            TotalSeconds += deltaTime;
            return true;
        }

        public void Draw(SpriteFont font, float totalElapsedSeconds, SpriteBatch spriteBatch)
        {
            var deltaTime = totalElapsedSeconds;
            this.Update(deltaTime);
            var fps = string.Format("FPS: {0}", this.RoundedAverageFramesPerSecond);

            if (font == null)
            {
                Console.WriteLine(fps);
            }
            else
            {
                spriteBatch.DrawString(font, fps, new Vector2(1, 1), Color.White);
            }
        }

        private int RoundedAverageFramesPerSecond { get { return (int)Math.Round(this.AverageFramesPerSecond); } }
    }
}

