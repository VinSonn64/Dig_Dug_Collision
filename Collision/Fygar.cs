using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Collision
{
    class Fygar : Microsoft.Xna.Framework.DrawableGameComponent
    {

        SpriteBatch myspriteBatch2;


        Texture2D FygarTexture;
        Vector2 FygarDir;
        Vector2 FygarLoc;
        Vector2 FygarLoc2;
        Vector2 FygarLoc3;
        float CharSpeed;

        DigDug digdug;

        Rectangle digdugBounds;
        Rectangle fygarBounds;
        Rectangle fygarBounds2;
        Rectangle fygarBounds3;

        public Fygar(Game game, DigDug digdug)
            : base(game)
        {
            this.digdug = digdug;
            
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            myspriteBatch2 = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            FygarDir = new Vector2(0, 0);
            FygarLoc = new Vector2(this.Game.GraphicsDevice.Viewport.Width+100,    0);
            FygarLoc2 = new Vector2(this.Game.GraphicsDevice.Viewport.Width+500,   200);
            FygarLoc3 = new Vector2(this.Game.GraphicsDevice.Viewport.Width+800,   400);
            FygarTexture = this.Game.Content.Load<Texture2D>("FygarChar");
            CharSpeed = 200; //Multiply the direction by this number to set speed
        
        }

        public override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //Exit();

            // TODO: Add your update logic here
            float time = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            //Move DigDug at a specific direction and speed per second
            FygarLoc = FygarLoc + ((new Vector2(-1, 0) * CharSpeed) * (time / 1000));
            FygarLoc2 = FygarLoc2 + ((new Vector2(-1, 0) * CharSpeed) * (time / 1000));
            FygarLoc3 = FygarLoc3 + ((new Vector2(-1, 0) * CharSpeed) * (time / 1000));

            digdugBounds = new Rectangle((int)digdug.DigDugLoc.X, (int)digdug.DigDugLoc.Y, (int)digdug.DigDugTexture.Width, (int)digdug.DigDugTexture.Height);
            fygarBounds = new Rectangle((int)this.FygarLoc.X, (int)this.FygarLoc.Y, (int)this.FygarTexture.Width, (int)this.FygarTexture.Height);
            fygarBounds2 = new Rectangle((int)this.FygarLoc2.X, (int)this.FygarLoc2.Y, (int)this.FygarTexture.Width, (int)this.FygarTexture.Height);
            fygarBounds3 = new Rectangle((int)this.FygarLoc3.X, (int)this.FygarLoc3.Y, (int)this.FygarTexture.Width, (int)this.FygarTexture.Height);
            if (!digdug.isKill)
            {
                FygarLocReset();
            }

            if (fygarBounds.Intersects(digdugBounds) || fygarBounds2.Intersects(digdugBounds) || fygarBounds3.Intersects(digdugBounds))
            {
              
                    digdug.Killed();
                
            }

        
        }





        public override void Draw(GameTime gameTime)
        {

            // TODO: Add your drawing code here
            myspriteBatch2.Begin();
            myspriteBatch2.Draw(FygarTexture, FygarLoc, Color.White);
            myspriteBatch2.Draw(FygarTexture, FygarLoc2, Color.White);
            myspriteBatch2.Draw(FygarTexture, FygarLoc3, Color.White);
            myspriteBatch2.End();
            base.Draw(gameTime);
        }

        public void FygarLocReset()
        {
            if (FygarLoc.X < 0)
            {
                FygarLoc.X = this.Game.GraphicsDevice.Viewport.Width+50;
                digdug.AddPoint();
                CharSpeed+=15;
                
            }
                if (FygarLoc2.X < 0)
                {
                    FygarLoc2.X = this.Game.GraphicsDevice.Viewport.Width+500;
                    digdug.AddPoint();
                    CharSpeed+=15;
                }
                if (FygarLoc3.X < 0)
                {
                    FygarLoc3.X = this.Game.GraphicsDevice.Viewport.Width+800;
                    digdug.AddPoint();
                    CharSpeed+=15;
                }
            }
        }
    }

