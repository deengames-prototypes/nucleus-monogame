using System;
using System.Collections.Generic;
using Nucleus.Ecs;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ninject;
using Nucleus.Ecs.Components;

namespace Nucleus.Core
{
    public class Screen : IDisposable
    {
        private static Screen currentScreen;

        private List<ImageComponent> images = new List<ImageComponent>();

        public Screen()
        {
            // You can't load content here, it's too early in the life-cycle
        }

        public void Add(Entity e) {
            if (e.Has<ImageComponent>())
            {
                var i = e.Get<ImageComponent>();
                this.images.Add(i);
            }
            else if (e.Has<SpriteSheetComponent>())
            {
                var i = e.Get<SpriteSheetComponent>();
                this.images.Add(i);
            }
        }

        public virtual void Initialize()
        {
            // You can load content here
            foreach (var image in images)
            {
                image.Initialize();
            }
        }

        public void Dispose()
        {
            foreach (var i in this.images)
            {
                i.Dispose();
            }

            this.images.Clear();
        }

        public static void ShowScreen(Screen s)
        {
            if (currentScreen != null)
            {
                currentScreen.Dispose();
            }

            currentScreen = s;
            s.Initialize();
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(GameTime gameTime)
        {
            foreach (var image in images)
            {
                image.Draw();
            }
        }

        public static Screen CurrentScreen { get { return currentScreen; } }

        public int Width { get { return CommonGame.Instance.Width; } }
        public int Height { get { return CommonGame.Instance.Height; } }
    }
}

