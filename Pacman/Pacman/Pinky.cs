using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Pinky : AEnnemy
    {
        protected bool intersected;
        public Pinky(SpriteManager s)
            : base(s, EOrientation.RIGHT)
        {
            orientationToSprite_.Add(EOrientation.LEFT, SpriteManager.ESprite.PINKYLEFT);
            orientationToSprite_.Add(EOrientation.RIGHT, SpriteManager.ESprite.PINKYRIGHT);
            orientationToSprite_.Add(EOrientation.UP, SpriteManager.ESprite.PINKYUP);
            orientationToSprite_.Add(EOrientation.DOWN, SpriteManager.ESprite.PINKYDOWN);
            orientationToSprite_.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.PINKYRIGHT);
            position_ = new Vector2(105, 140);
            sprite_ = new Sprite(position_, orientationToSprite_[orientation_]);
            orientation_ = EOrientation.LEFT;
            intersected = false;
        }

        //FOLLOW WITH INTERSECTIONS
        public override void IA()
        {
            EOrientation tmp;
            if (blocked_)
            {
                intersected = false;
                if (orientation_ != destination_)
                    orientation_ = destination_;
                else
                {
                    while ((tmp = (EOrientation)random_.Next(5)) == orientation_) ;
                    orientation_ = tmp;
                }
            }
            if (atIntersection_ && !intersected)
            {
                intersected = true;
                if (orientation_ != destination_ && freePath_[destination_])
                    orientation_ = destination_;
                else
                {
                    while (!freePath_[(tmp = (EOrientation)random_.Next(5))]);
                    orientation_ = tmp;
                }
            }
        }
    }
}
