using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Clyde : AEnnemy
    {
        //Random rand;
        bool intersected;
        public Clyde(SpriteManager s)
            : base(s, EOrientation.DOWN)
        {
            orientationToSprite_.Add(EOrientation.LEFT, SpriteManager.ESprite.CLYDELEFT);
            orientationToSprite_.Add(EOrientation.RIGHT, SpriteManager.ESprite.CLYDERIGHT);
            orientationToSprite_.Add(EOrientation.UP, SpriteManager.ESprite.CLYDEUP);
            orientationToSprite_.Add(EOrientation.DOWN, SpriteManager.ESprite.CLYDEDOWN);
            orientationToSprite_.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.CLYDEDOWN);
            position_ = new Vector2(137, 140);
            sprite_ = new Sprite(position_, orientationToSprite_[orientation_]);
            orientation_ = EOrientation.RIGHT;
            intersected = false;
        }

        public override void IA()
        {
            //RANDOM WITH INTERSECTIONS
            EOrientation tmp;
            if (blocked_)
            {
                intersected = false;
                while ((tmp = (EOrientation)random_.Next(5)) == orientation_ || tmp == EOrientation.NEUTRAL) ;
                orientation_ = tmp;
            }
            if (atIntersection_ && !intersected)
            {
                while ((tmp = (EOrientation)random_.Next(5)) == orientation_ || tmp == EOrientation.NEUTRAL) ;
                orientation_ = tmp;
                intersected = true;
            }
        }
    }
}
