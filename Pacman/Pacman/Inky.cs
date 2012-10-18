using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Inky : AEnnemy
    {
        //protected Random rand;
        public Inky(SpriteManager s)
            : base(s, EOrientation.UP)
        {
            orientationToSprite_.Add(EOrientation.LEFT, SpriteManager.ESprite.INKYLEFT);
            orientationToSprite_.Add(EOrientation.RIGHT, SpriteManager.ESprite.INKYRIGHT);
            orientationToSprite_.Add(EOrientation.UP, SpriteManager.ESprite.INKYUP);
            orientationToSprite_.Add(EOrientation.DOWN, SpriteManager.ESprite.INKYDOWN);
            orientationToSprite_.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.INKYUP);
            position_ = new Vector2(89, 140);
            sprite_ = new Sprite(position_, orientationToSprite_[orientation_]);
            orientation_ = EOrientation.LEFT;
        }

        //FOLLOW WITHOUT INTERSECTIONS
        public override void IA()
        {
            EOrientation tmp;
            if (blocked_)
            {
                if (orientation_ != destination_)
                    orientation_ = destination_;
                else
                {
                    while ((tmp = (EOrientation)random_.Next(5)) == orientation_ || tmp == EOrientation.NEUTRAL) ;
                    orientation_ = tmp;
                }
            }
        }
    }
}
