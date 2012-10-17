using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Clyde : ACharacter
    {
        Random rand;
        bool intersected;
        public Clyde(SpriteManager s)
            : base(s)
        {
            rand = new Random();
            ortToSp.Add(EOrientation.LEFT, SpriteManager.ESprite.CLYDELEFT);
            ortToSp.Add(EOrientation.RIGHT, SpriteManager.ESprite.CLYDERIGHT);
            ortToSp.Add(EOrientation.UP, SpriteManager.ESprite.CLYDEUP);
            ortToSp.Add(EOrientation.DOWN, SpriteManager.ESprite.CLYDEDOWN);
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.FRIGHTGHOST);
            pos = new Vector2(145, 140);
            sp = new Sprite(pos, ortToSp[orientation]);
            orientation = EOrientation.LEFT;
            intersected = false;
        }

        public override void update(Microsoft.Xna.Framework.GameTime gt)
        {
            //RANDOM WITH INTERSECTIONS
            EOrientation tmp;
            base.update(gt);
            if (blocked)
            {
                intersected = false;
                while ((tmp = (EOrientation)rand.Next(5)) == orientation || tmp == EOrientation.NEUTRAL) ;
                orientation = tmp;
            }
            if (intersection && !intersected)
            {
                while ((tmp = (EOrientation)rand.Next(5)) == orientation || tmp == EOrientation.NEUTRAL) ;
                orientation = tmp;
                intersected = true;
            }
        }
    }
}
