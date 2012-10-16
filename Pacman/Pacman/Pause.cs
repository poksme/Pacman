using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    class Pause : AScene
    {
        public Pause(SceneManager sm, SpriteManager spm) : base(sm, spm)
        {
            lastState = GamePad.GetState(PlayerIndex.One);
        }

        public override void load()
        {

        }

        public override void update(GameTime gt)
        {
            currentState = GamePad.GetState(PlayerIndex.One);

            if (currentState.IsConnected)
            {
                if (currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.activateScene(SceneManager.EScene.LEVEL);
                }
            }
            lastState = currentState;
        }

        public override void draw()
        {
        }

        public override void unload()
        {
        }
    }
}
