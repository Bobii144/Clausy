using ClausyGame.Objects;
using ClausyGame.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClausyGame
{

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class ClausyGame : Game
    {
        GraphicsDeviceManager graphics;
        Texture2D textureBall;
        SpriteBatch spriteBatch;
        Player player;
        GamePhysics physics;
        Snow snow;
        World world;

        public ClausyGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            player = new Player
            {
                Speed = 100f,
                Position = new Vector2(0, 0)
            };
            snow = new Snow
            {
                Speed = 0f,
                Position = new Vector2(150, 150)
            };
            world = new World
            {
                Width = graphics.PreferredBackBufferWidth,
                Height = graphics.PreferredBackBufferHeight
            };
            physics = new GamePhysics();

            base.Initialize();
            // TODO: Add your initialization logic here
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.

            spriteBatch = new SpriteBatch(GraphicsDevice);
            snow.Texture = Content.Load<Texture2D>("ball");
            player.Texture = Content.Load<Texture2D>("ball");
            player.Init();
            snow.Init();


            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                player.Position.Y -= player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                player.Position.Y += player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                player.Position.X -= player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                player.Position.X += player.Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(physics.CollisionVsObject(player, snow))
            {
                snow.Position.X += 1 ;
            } 
            if (physics.OutOfBounds(player, world))
            {
                snow.Position.X -= 1;
            }
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(snow.Texture, snow.Position, Color.White);
            spriteBatch.Draw(player.Texture, player.Position, Color.White);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
