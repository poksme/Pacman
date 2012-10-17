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
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.FRIGHTGHOST);
            pos = new Vector2(129, 140);
            sp = new Sprite(pos, ortToSp[orientation]);
            orientation = EOrientation.LEFT;
        }
        //RANDOM WITHOUT INTERSECTIONS
        public override void update(GameTime gt)
        {
            EOrientation tmp;
            base.update(gt);
            if (blocked)
            {
                while ((tmp = (EOrientation)rand.Next(5)) == orientation || tmp == EOrientation.NEUTRAL) ;
                orientation = tmp;
            }
        }
    }
}
