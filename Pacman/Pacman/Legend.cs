using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    class Legend : AScene
    {
        private Vector2 textPos;

        public Legend(SceneManager scm, SpriteManager spm)
            : base(scm, spm)
        {
            lastState = GamePad.GetState(PlayerIndex.One);
            textPos = Vector2.Zero;
        }

        public override void load()
        {

        }

        public override void update(GameTime gt)
        {
            currentState = GamePad.GetState(PlayerIndex.One);


            lastState = currentState;
        }

        public override void draw()
        {
            spm_.drawLegend();
            textPos.X = 10;
            textPos.Y = 200;
            spm_.vanillaDraw(SpriteManager.ESprite.A, textPos);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Zoom out", textPos);

            textPos.X = 10;
            textPos.Y = 250;
            spm_.vanillaDraw(SpriteManager.ESprite.B, textPos);
            textPos.X += 40;
            textPos.Y += 10;
            spm_.drawText("Zoom in", textPos);
        }

        public override void unload()
        {
        }
    }
}
