using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Pacman
{
    class Pause : AScene
    {
        private Vector2 textPos;

        public Pause(SceneManager sm, SpriteManager spm, SoundManager som)
            : base(sm, spm, som)
        {
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
                if (currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.activateScene(SceneManager.EScene.LEVEL);
                }
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
            spm_.centerDrawText("Pause!", 0, -40);

            textPos = spm_.getCenter();
            textPos.X -= 90;
            textPos.Y += 10;
            spm_.vanillaDraw(SpriteManager.ESprite.START, textPos);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Resume", textPos);

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
        }

        public override void unload()
        {
        }
    }
}
