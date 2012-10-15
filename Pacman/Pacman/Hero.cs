using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Hero : Character
    {
        Boolean blocked;
        public Hero(EOrientation ort):base(ort)
        {
            ortToSp = new Dictionary<EOrientation,SpriteManager.ESprite>();
            ortToSp.Add(EOrientation.LEFT, SpriteManager.ESprite.PACLEFT);
            ortToSp.Add(EOrientation.RIGHT, SpriteManager.ESprite.PACRIGHT);
            ortToSp.Add(EOrientation.UP, SpriteManager.ESprite.PACUP);
            ortToSp.Add(EOrientation.DOWN, SpriteManager.ESprite.PACDOWN);
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.PACNEUTRAL);
            pos = new Vector2(113, 92);
            sp = new Sprite(pos, ortToSp[ort]);
            blocked = true;
        }

        public void update(GameTime gt)
        {
            if (!blocked)
            {
                sp.id = ortToSp[orientation];
                switch (orientation)
                {
                    case (EOrientation.LEFT):
                        pos.X = pos.X - 1;
                        break;
                    case (EOrientation.RIGHT):
                        pos.X = pos.X + 1;
                        break;
                    case (EOrientation.UP):
                        pos.Y = pos.Y - 1;
                        break;
                    case (EOrientation.DOWN):
                        pos.Y = pos.Y + 1;
                        break;
                    default:
                        break;
                }
                animate(gt);
            }
            draw();
        }
        public void setBlocked(Boolean b)
        {
            blocked = b;
        }
    }
}
