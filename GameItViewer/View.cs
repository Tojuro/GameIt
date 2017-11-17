using GameItShared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace GameItViewer
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class View : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;
        ViewDefinition ViewDefinition;

        public View(ViewDefinition viewDefinition)
        {
            ViewDefinition = viewDefinition;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.ApplyChanges();            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
           
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("Verdana");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
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
            
            base.Update(gameTime);
        }

        private int BarStart = 500;
        private int BarLength = 1220;

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            spriteBatch.Begin();

            var startY = 99;

                if (ViewDefinition.ProgressBar != null)
                {
                    spriteBatch.DrawString(font, ViewDefinition.ProgressBar.Title??string.Empty, new Vector2(BarStart, startY), Color.Black);
                    if (ViewDefinition.ProgressBar.HasBackBar && ViewDefinition.ProgressBar.BackBar != null)
                    {
                        var bbarRec = new Rectangle(BarStart, startY, BarLength, 62);
                        Primitives2D.FillRectangleRound(spriteBatch, bbarRec, Color.Gray, ViewDefinition.ProgressBar.BackBar.Text, Color.White, font, ViewDefinition.ProgressBar.BackBar.TextAlign);
                    }
                    foreach (var pBar in ViewDefinition.ProgressBar.BarLayers)
                    {
                        var rect = new Rectangle(BarStart, startY+1, pBar.Length, 60);
                        Primitives2D.FillRectangleRound(spriteBatch, rect, pBar.Color, pBar.Text, Color.White, font, pBar.TextAlign);
                    }
                    startY += 125;
                }

                int i = 0;
                var rowRec = new Rectangle(BarStart, 400, 1420, 50);
                foreach(var row in ViewDefinition.Rows)
                {
                    if (i % 2 == 0)
                    {
                        var rect = new Rectangle(BarStart, startY, BarLength, 40);
                        Primitives2D.FillRectangle(spriteBatch, rect, Color.LightGray);
                    }
                    else
                    {
                        var rect = new Rectangle(BarStart, startY, BarLength, 40);
                        Primitives2D.FillRectangle(spriteBatch, rect, Color.Gray);
                    }

                    ResetColorQueue();

                    var startX = BarStart;
                    foreach (var val in row.Values)
                    {
                        var rect = new Rectangle(startX, startY, val.Value, 40);
                        Primitives2D.FillRectangle(spriteBatch, rect, ColorQueue.Dequeue());

                        startX += val.Value;

                        if (ColorQueue.Count <= 0)
                            ResetColorQueue();
                    }

                    spriteBatch.DrawString(font, row.Name, new Vector2(BarStart+20, startY), Color.White);

                    i++;
                    startY += 44;
                }






            //var rectangle1 = new Rectangle(100, 300, 455, 50);
            //Primitives2D.FillRectangleRound(spriteBatch, rectangle1, Color.Blue, "Team   Blue", Color.White, font);

            //var rectangle3 = new Rectangle(100, 100, 388, 50);
            //Primitives2D.FillRectangleRound(spriteBatch, rectangle3, Color.Purple, "Team   Purple", Color.White, font);

            //var rectangle2 = new Rectangle(100, 200, 600, 50);
            //Primitives2D.FillRectangleRound(spriteBatch, rectangle2, Color.Red, "Team   Red", Color.White, font);


            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Queue<Color> ColorQueue;

        private void ResetColorQueue()
        {
            ColorQueue = new Queue<Color>(
                new List<Color>
                {
                    Color.Blue,
                    Color.DodgerBlue,
                    Color.BlueViolet,
                    Color.CadetBlue,
                    Color.CornflowerBlue,
                    Color.LightBlue,
                });            
        }

                    //Color.Red,
                    //Color.Blue,
                    //Color.Yellow,
                    //Color.Green,
                    //Color.Pink,
                    //Color.DodgerBlue,
                    //Color.Orange,
                    //Color.ForestGreen,
                    //Color.DarkRed,
                    //Color.LightBlue,
                    //Color.LawnGreen,


    }
}
