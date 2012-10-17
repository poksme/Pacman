using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Inky : ACharacter
    {
        Random rand;
        bool intersected;
        public Inky(SpriteManager s)
            : base(s)
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
