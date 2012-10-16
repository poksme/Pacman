using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Blinky : ACharacter
    {
        Random rand;
        public Blinky(SpriteManager s) : base(s)
        {
            rand = new Random();
            ortToSp.Add(EOrientation.LEFT, SpriteManager.ESprite.BLINKYLEFT);
            ortToSp.Add(EOrientation.RIGHT, SpriteManager.ESprite.BLINKYRIGHT);
            ortToSp.Add(EOrientation.UP, SpriteManager.ESprite.BLINKYUP);
            ortToSp.Add(EOrientation.DOWN, SpriteManager.ESprite.BLINKYDOWN);
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.DEADGHOST);
            pos = new Vector2(113, 140);
            sp = new Sprite(pos, ortToSp[orientation]);
            orientation = EOrientation.LEFT;
        }
        public override void update(GameTime gt)
        {
            base.update(gt);
            if (blocked)
            {
                orientation = (EOrientation)rand.Next(5);
            }
        }
    }
}
