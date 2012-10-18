using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Blinky : AEnnemy
    {
        //Random random_;
        public Blinky(SpriteManager s) : 
            base(s, EOrientation.LEFT)
        {
            orientationToSprite_.Add(EOrientation.LEFT, SpriteManager.ESprite.BLINKYLEFT);
            orientationToSprite_.Add(EOrientation.RIGHT, SpriteManager.ESprite.BLINKYRIGHT);
            orientationToSprite_.Add(EOrientation.UP, SpriteManager.ESprite.BLINKYUP);
            orientationToSprite_.Add(EOrientation.DOWN, SpriteManager.ESprite.BLINKYDOWN);
            orientationToSprite_.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.BLINKYLEFT);
            position_ = new Vector2(121, 140);
            sprite_ = new Sprite(position_, orientationToSprite_[orientation_]);
            orientation_ = EOrientation.RIGHT;
        }
        //RANDOM WITHOUT INTERSECTIONS
        public override void IA()
        {
            EOrientation tmp;
            if (blocked_)
            {
                while ((tmp = (EOrientation)random_.Next(5)) == orientation_ || tmp == EOrientation.NEUTRAL) ;
                orientation_ = tmp;
            }
        }
    }
}
