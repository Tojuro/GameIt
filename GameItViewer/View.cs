using GameItShared;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

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

            var startY = 25;

            // PROGRESS BAR

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
                startY += 100;
            }

            //INDIVIDUAL LEADERBOARD
            if (ViewDefinition.TeamBars.Any())
            {
                spriteBatch.DrawString(font, "TEAM   LEADERBOARD", new Vector2(BarStart, startY), Color.DarkBlue);
                startY += 45;

                foreach (var row in ViewDefinition.TeamBars)
                {
                    var rect = new Rectangle(BarStart, startY, row.Length, 40);
                    Primitives2D.FillRectangleRound(spriteBatch, rect, row.Color, row.Text, Color.White, font, row.TextAlign);

                    startY += 48;
                }

                int i = 0;
                startY += 50;
            }

                //INDIVIDUAL LEADERBOARD

                if (ViewDefinition.IndividualLeaderBoard.Any())
            {
                spriteBatch.DrawString(font, "INDIVIDUAL   LEADERBOARD", new Vector2(BarStart, startY), Color.DarkBlue);
                startY += 45;

                int i = 0;
                foreach (var row in ViewDefinition.IndividualLeaderBoard)
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

                    spriteBatch.DrawString(font, row.Name, new Vector2(BarStart + 20, startY), Color.White);

                    i++;
                    startY += 44;
                }

                startY += 48;
                
                ResetColorQueue();
                var keyStartX = BarStart;
                
                var labelSize = (int)font.MeasureString("KEY").X;
                spriteBatch.DrawString(font, "KEY", new Vector2(keyStartX, startY), Color.Black);

                keyStartX += labelSize + 20;

                foreach (var title in ViewDefinition.IndividualLeaderBoard.FirstOrDefault().Values)
                {
                    var xSize = (int)font.MeasureString(title.Key).X;
                    var rect = new Rectangle(keyStartX, startY, xSize+10, 40);  
                    Primitives2D.FillRectangle(spriteBatch, rect, ColorQueue.Dequeue());
                    spriteBatch.DrawString(font, title.Key, new Vector2(rect.X+5, rect.Y), Color.White);
                    keyStartX += xSize + 25;
                }

                startY += 48;
            }
            
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private Queue<Color> ColorQueue;

        private void ResetColorQueue()
        {
            ColorQueue = new Queue<Color>(
                new List<Color>
                {
                    Color.IndianRed,
                    Color.CornflowerBlue,
                    Color.DarkOliveGreen,
                    Color.Orange,
                    Color.Crimson,
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
