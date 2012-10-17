using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Pinky : ACharacter
    {
        protected Random rand;
        protected bool intersected;
        public Pinky(SpriteManager s)
            : base(s)
        {
            rand = new Random();
            ortToSp.Add(EOrientation.LEFT, SpriteManager.ESprite.PINKYLEFT);
            ortToSp.Add(EOrientation.RIGHT, SpriteManager.ESprite.PINKYRIGHT);
            ortToSp.Add(EOrientation.UP, SpriteManager.ESprite.PINKYUP);
            ortToSp.Add(EOrientation.DOWN, SpriteManager.ESprite.PINKYDOWN);
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.FRIGHTGHOST);
            pos = new Vector2(113, 140);
            sp = new Sprite(pos, ortToSp[orientation]);
            orientation = EOrientation.LEFT;
            intersected = false;
        }

        //FOLLOW WITH INTERSECTIONS
        public override void update(GameTime gt)
        {
            EOrientation tmp;
            base.update(gt);
            if (blocked)
            {
                intersected = false;
                if (orientation != destination)
                    orientation = destination;
                else
                {
                    while ((tmp = (EOrientation)rand.Next(5)) == orientation || tmp == EOrientation.NEUTRAL) ;
                    orientation = tmp;
                }
            }
            if (intersection && !intersected)
            {
                intersected = true;
                if (orientation != destination)
                    orientation = destination;
                else
                {
                    while ((tmp = (EOrientation)rand.Next(5)) == orientation || tmp == EOrientation.NEUTRAL) ;
                    orientation = tmp;
                }
            }
        }
    }
}
