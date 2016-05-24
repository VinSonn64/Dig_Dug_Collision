using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Collision
{
    class DigDug : Microsoft.Xna.Framework.DrawableGameComponent
    {
        
        SpriteBatch myspriteBatch;
        SpriteFont score;
        public Texture2D DigDugTexture;
        public static int points;
        public Vector2 DigDugLoc;
        Vector2 DigDugDir;
        float CharSpeed;
        public bool isKill=false;

        private Game1 game1;
  
        public int AddPoint()
        { points++;
        return points;
        }
         public int ShowPoints()
        {
            return points;
        }

         public void Killed()
        {
            isKill = true;
            
        }


        public DigDug(Game1 game1):base(game1)
        {
            // TODO: Complete member initialization
            this.game1 = game1;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            myspriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            DigDugTexture = this.Game.Content.Load<Texture2D>("DigDugChar");
            score = this.Game.Content.Load<SpriteFont>("score");
            DigDugDir = new Vector2(0, 0);
            DigDugLoc = new Vector2(this.Game.GraphicsDevice.Viewport.Width / 10, this.Game.GraphicsDevice.Viewport.Height / 2);
           
            CharSpeed = 15; //Multiply the direction by this number to set speed

        }

        public override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit();

            // TODO: Add your update logic here
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //Move DigDug at a specific direction and speed per second
            DigDugLoc = DigDugLoc + ((DigDugDir * CharSpeed) * (time / 1000));

            HandleInput();
            block();

            base.Update(gameTime);
        }

        private void HandleInput()
        {
            //Moves DigDug once a button is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                DigDugDir += new Vector2(0, 1);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                DigDugDir += new Vector2(0, -1);

            }
            /*
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                DigDugDir += new Vector2(-1, 0);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                DigDugDir += new Vector2(1, 0);
            }*/

            //if no keys are presed, sets the direction to 0, stopping it at its current location
            if (Keyboard.GetState().GetPressedKeys().Length == 0)
            {
                DigDugDir = DigDugDir - DigDugDir;
            }
        }
        
        private void block()//DigDug can't leave the screen
        {
            if(DigDugLoc.Y <0)
            {
                DigDugLoc.Y = 0;
            }
            else if (DigDugLoc.Y > this.Game.GraphicsDevice.Viewport.Height - DigDugTexture.Height)
            {
                DigDugLoc.Y = this.Game.GraphicsDevice.Viewport.Height-DigDugTexture.Height;
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SaddleBrown);

            // TODO: Add your drawing code here
            myspriteBatch.Begin();
            myspriteBatch.Draw(DigDugTexture, DigDugLoc, Color.White);//Draw DigDug at the center of the screen
            if(isKill)//if Killed Game Over
            {
                myspriteBatch.DrawString(score, "Game Over: Your High Score is "+points.ToString(), new Vector2(50, 10), Color.White);
            }
            else
            {
                myspriteBatch.DrawString(score, "Score: " + points.ToString(), new Vector2(50, 10), Color.White);//if not Killed, Display Score
            }
            myspriteBatch.DrawString(score, "Up and Down Arrows to move. Dodge as many as possible.", new Vector2(50, 450), Color.White);
            myspriteBatch.End();
            base.Draw(gameTime);
        }
    }

}
