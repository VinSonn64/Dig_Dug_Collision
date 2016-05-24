using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Collision
{
    class Doge : Microsoft.Xna.Framework.DrawableGameComponent
    {

        SpriteBatch myspriteBatch2;

        Texture2D DogeTexture;
        Vector2 DogeLoc;
        DigDug digdug;
        Vector2 DogeDir;
        float CharSpeed;

        public Doge(Game game, DigDug digdug)
            : base(game)
        {
            this.digdug = digdug;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            myspriteBatch2 = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            DogeDir = new Vector2(0, 0);
            DogeLoc = new Vector2(this.Game.GraphicsDevice.Viewport.Width, 120);


            DogeTexture = this.Game.Content.Load<Texture2D>("Doge");
            CharSpeed =500; //Multiply the direction by this number to set speed
        }

        public override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();

            // TODO: Add your update logic here
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //Move DigDug at a specific direction and speed per second
            if(digdug.isKill)
            DogeLoc = DogeLoc + ((new Vector2(-1, 0) * CharSpeed) * (time / 1000));


            
            base.Update(gameTime);
        }



        public override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            myspriteBatch2.Begin();

            if (digdug.isKill)
            {
                myspriteBatch2.Draw(DogeTexture, DogeLoc, Color.White);
            }
            myspriteBatch2.End();
            base.Draw(gameTime);
        }

        public void DogeLocReset()
        {
            if (DogeLoc.X < 0)
            {
                DogeLoc.X = this.Game.GraphicsDevice.Viewport.Width;

            }

        }
    }
}

