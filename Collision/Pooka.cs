using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Collision
{
    class Pooka : Microsoft.Xna.Framework.DrawableGameComponent
    {

        SpriteBatch myspriteBatch2;

        Texture2D PookaTexture;
        Vector2 PookaLoc;
        Vector2 PookaLoc2;
        
        DigDug digdug;
        Vector2 PookaDir;
        float CharSpeed;
        Rectangle digdugBounds;
        Rectangle pookaBounds;
        Rectangle pookaBounds2;

        public Pooka(Game game, DigDug digdug)
            : base(game)
        {
            this.digdug = digdug;
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            myspriteBatch2 = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            PookaDir = new Vector2(0, 0);
            PookaLoc = new Vector2(this.Game.GraphicsDevice.Viewport.Width +350, 120);
            PookaLoc2 = new Vector2(this.Game.GraphicsDevice.Viewport.Width + 900, 350);
     
            PookaTexture = this.Game.Content.Load<Texture2D>("PookaChar");
            CharSpeed = 200; //Multiply the direction by this number to set speed


        }

        public override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();

            // TODO: Add your update logic here
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //Move DigDug at a specific direction and speed per second
            PookaLoc = PookaLoc + ((new Vector2(-1, 0) * CharSpeed) * (time / 1000));
            PookaLoc2 = PookaLoc2 + ((new Vector2(-1, 0) * CharSpeed) * (time / 1000));

            if (!digdug.isKill)
            {
                PookaLocReset();
            }

            digdugBounds = new Rectangle((int)digdug.DigDugLoc.X, (int)digdug.DigDugLoc.Y, (int)digdug.DigDugTexture.Width, (int)digdug.DigDugTexture.Height);
            pookaBounds = new Rectangle((int)this.PookaLoc.X, (int)this.PookaLoc.Y, (int)this.PookaTexture.Width, (int)this.PookaTexture.Height);
            pookaBounds2 = new Rectangle((int)this.PookaLoc2.X, (int)this.PookaLoc2.Y, (int)this.PookaTexture.Width, (int)this.PookaTexture.Height);
            base.Update(gameTime);
            if (pookaBounds.Intersects(digdugBounds) || pookaBounds2.Intersects(digdugBounds) )
            {
                digdug.Killed();
            }
        }



        public override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            myspriteBatch2.Begin();
            myspriteBatch2.Draw(PookaTexture, PookaLoc, Color.White);
            myspriteBatch2.Draw(PookaTexture, PookaLoc2, Color.White);

            myspriteBatch2.End();
            base.Draw(gameTime);
        }

        public void PookaLocReset()
        {
            if (PookaLoc.X < 0)
            {
                PookaLoc.X = this.Game.GraphicsDevice.Viewport.Width + 350;
                digdug.AddPoint();
                CharSpeed += 20;

            }
            if (PookaLoc2.X < 0)
            {
                PookaLoc2.X = this.Game.GraphicsDevice.Viewport.Width + 900;
                digdug.AddPoint();
                CharSpeed += 20;
            }
        }
    }
}


