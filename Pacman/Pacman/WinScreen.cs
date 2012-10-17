using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    class WinScreen : AScene
    {
                private Vector2 textPos;
                private SceneManager sm_;
                public WinScreen(SceneManager sm, SpriteManager spm, SoundManager som)
                    : base(sm, spm, som)
        {
            lastState = GamePad.GetState(PlayerIndex.One);
            sm_ = sm;
        }

        public override void load()
        {

        }

        public override void update(GameTime gt)
        {
            currentState = GamePad.GetState(PlayerIndex.One);
            //currentState = cur;
            //lastState = old;
            if (currentState.IsConnected)
            {
                if (currentState.Buttons.B == ButtonState.Pressed && lastState.Buttons.B == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.activateScene(SceneManager.EScene.TITLE);
                }

                if (currentState.Buttons.Back == ButtonState.Pressed && lastState.Buttons.Back == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.exit();
                }
            }
            lastState = currentState;
        }

        public override void draw()
        {
            spm_.centerDrawText("Congratulation you won! Your score is " + sm_.getBonus() + " points!", 0, -40);

            //textPos = spm_.getCenter();
            //textPos.X -= 90;
            //textPos.Y += 10;
            //spm_.vanillaDraw(SpriteManager.ESprite.START, textPos);
            //textPos.X += 40;
            //textPos.Y += 10;
            //spm_.drawText("Resume", textPos);

            textPos = spm_.getCenter();
            textPos.X -= 90;
            textPos.Y += 50;
            spm_.vanillaDraw(SpriteManager.ESprite.B, textPos);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Exit (to title screen)", textPos);

            textPos = spm_.getCenter();
            textPos.X -= 90;
            textPos.Y += 90;
            spm_.vanillaDraw(SpriteManager.ESprite.START, textPos, SpriteEffects.FlipHorizontally);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Exit (to windows)", textPos);


            //textPos.X = 10;
            //textPos.Y += 40;
            //spm_.vanillaDraw(SpriteManager.ESprite.A, textPos);
            //textPos.X += 40;
            //textPos.Y += 10;
            //spm_.drawText("Zoom out", textPos);

            //textPos.X = 10;
            //textPos.Y += 40;
            //spm_.vanillaDraw(SpriteManager.ESprite.B, textPos);
            //textPos.X += 40;
            //textPos.Y += 10;
            //spm_.drawText("Zoom in", textPos);

            //textPos.X = 10;
            //textPos.Y += 40;
            //spm_.vanillaDraw(SpriteManager.ESprite.Y, textPos);
            //textPos.X += 40;
            //textPos.Y += 10;
        }

        public override void unload()
        {
        }
    }
}
