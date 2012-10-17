using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Inky : ACharacter
    {
        protected Random rand;
        public Inky(SpriteManager s)
            : base(s)
        {
            rand = new Random();
            ortToSp.Add(EOrientation.LEFT, SpriteManager.ESprite.INKYLEFT);
            ortToSp.Add(EOrientation.RIGHT, SpriteManager.ESprite.INKYRIGHT);
            ortToSp.Add(EOrientation.UP, SpriteManager.ESprite.INKYUP);
            ortToSp.Add(EOrientation.DOWN, SpriteManager.ESprite.INKYDOWN);
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.FRIGHTGHOST);
            pos = new Vector2(97, 140);
            sp = new Sprite(pos, ortToSp[orientation]);
            orientation = EOrientation.LEFT;
        }

        //FOLLOW WITHOUT INTERSECTIONS
        public override void update(GameTime gt)
        {
            EOrientation tmp;
            base.update(gt);
            if (blocked)
            {
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
