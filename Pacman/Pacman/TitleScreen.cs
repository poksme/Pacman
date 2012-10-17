using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    class TitleScreen : AScene
    {
        public TitleScreen(SceneManager sm, SpriteManager spm_, SoundManager som)
            : base(sm, spm_, som)
        {
            lastState = GamePad.GetState(PlayerIndex.One);
            som_.play(SoundManager.ESound.BEGIN);
        }

        public override void load()
        {
        }

        public override void update(GameTime gt)
        {
            //currentState = cur;
            //lastState = old;
            currentState = GamePad.GetState(PlayerIndex.One);

            if (currentState.IsConnected)
            {
                if (currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.initScene(SceneManager.EScene.LEVEL);
                    scm_.activateScene(SceneManager.EScene.LEVEL);
                }
            }
            lastState = currentState;
        }

        public override void draw()
        {
            spm_.drawTitle();
        }

        public override void unload()
        {
        }
    }
}
