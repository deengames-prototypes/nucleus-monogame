using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Ninject;
using Nucleus.Utils;

namespace Nucleus.Core
{
    public class CommonGame : Game
    {
        public static CommonGame Instance { get; private set; }
        public bool ShowFps { get; set; }

        internal bool Initialized { get; private set; }
        internal IKernel Kernel { get; private set; }

        protected readonly GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        private readonly FrameCounter frameCounter = new FrameCounter();
        private SpriteFont defaultFont;

        public CommonGame()
        {
            if (Instance != null)
            {
                throw new InvalidOperationException("Can't create more than one instance of the game class!");
            }

            Instance = this;
            this.Kernel = new StandardKernel();

            graphics = new GraphicsDeviceManager (this);
            Content.RootDirectory = "Content";              
            graphics.IsFullScreen = false;      
            graphics.PreferredBackBufferWidth = 960;
            graphics.PreferredBackBufferHeight = 540;

            this.ShowFps = true;
        }

        internal int Width { get { return graphics.PreferredBackBufferWidth; } }
        internal int Height { get { return graphics.PreferredBackBufferHeight; } }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize ();
            this.Initialized = true;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent ()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            this.spriteBatch = new SpriteBatch (GraphicsDevice);

            // Setup DI bindings
			this.Kernel.Bind<SpriteBatch>().ToConstant(this.spriteBatch);
			// Why does the first get call always fail? 'tis strange.
			try {
				this.Kernel.Get<SpriteBatch>();
			} catch (NullReferenceException) {
				// As expected, sadly. See:
				// http://stackoverflow.com/questions/8971006/best-way-to-create-spritebatch-when-wrapping-underlying-objects
			}

            this.defaultFont = Content.Load<SpriteFont>("Kooten");
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update (GameTime gameTime)
        {
            // For Mobile devices, this logic will close the Game when the Back button is pressed
            // Exit() is obsolete on iOS
            #if !__IOS__
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            #endif

            // TODO: Add your update logic here         
            base.Update(gameTime);

            if (Screen.CurrentScreen != null)
            {
                Screen.CurrentScreen.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw (GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear (Color.Black);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.NonPremultiplied);

            if (Screen.CurrentScreen != null)
            {
                Screen.CurrentScreen.Draw(gameTime);
            }

            if (this.ShowFps)
            {
                frameCounter.Draw(this.defaultFont, (float)gameTime.ElapsedGameTime.TotalSeconds, this.spriteBatch);
            }

            spriteBatch.End();

            base.Draw (gameTime);
        }
    }
}

