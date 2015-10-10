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

        private List<SpriteComponent> sprites = new List<SpriteComponent>();

        public Screen()
        {
            // You can't load content here, it's too early in the life-cycle
        }

        public void Add(SpriteComponent s) {
            this.sprites.Add(s);
        }

        public virtual void Initialize() {
            // You can load content here
            foreach (var sprite in sprites)
            {
                sprite.Initialize();
            }
        }

        public void Dispose()
        {
            foreach (var s in this.sprites)
            {
                s.Dispose();
            }

            this.sprites.Clear();
        }

        public static void ShowScreen(Screen s) {
            if (currentScreen != null)
            {
                currentScreen.Dispose();
            }

            currentScreen = s;
            s.Initialize();
        }

        public void Draw(GameTime gameTime)
        {
            foreach (var sprite in sprites)
            {
                sprite.Draw();
            }
        }

        public static Screen CurrentScreen { get { return currentScreen; } }
    }
}

