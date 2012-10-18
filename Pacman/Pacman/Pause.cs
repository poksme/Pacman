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

        bool recent;
        public Pause(SceneManager sm, SpriteManager spm, SoundManager som)
            : base(sm, spm, som)
        {
            recent = false;
        }

        public override void activate()
        {
            base.activate();
            som_.play(SoundManager.ESound.PAUSE);
            recent = true;
        }

        public override void desactivate()
        {
            base.desactivate();
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
                if (!recent && currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    som_.play(SoundManager.ESound.PAUSE, -0.2f);
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
            recent = false;
        }

        public override void draw()
        {
            spm_.drawCenteredText("Pause!", 0, -40);

            textPos = spm_.getCenter();
            textPos.X -= 90;
            textPos.Y += 10;
            spm_.drawSprite(SpriteManager.ESprite.START, textPos);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Resume", textPos);

            textPos = spm_.getCenter();
            textPos.X -= 90;
            textPos.Y += 50;
            spm_.drawSprite(SpriteManager.ESprite.B, textPos);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Exit (to title screen)", textPos);

            textPos = spm_.getCenter();
            textPos.X -= 90;
            textPos.Y += 90;
            spm_.drawSprite(SpriteManager.ESprite.START, textPos, SpriteEffects.FlipHorizontally);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Exit (to windows)", textPos);
        }

        public override void unload()
        {
        }
    }
}
