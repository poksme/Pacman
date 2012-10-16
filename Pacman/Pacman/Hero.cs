using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Hero : ACharacter
    {
        public Hero(SpriteManager s):base(s)
        {
            ortToSp.Add(EOrientation.LEFT, SpriteManager.ESprite.PACLEFT);
            ortToSp.Add(EOrientation.RIGHT, SpriteManager.ESprite.PACRIGHT);
            ortToSp.Add(EOrientation.UP, SpriteManager.ESprite.PACUP);
            ortToSp.Add(EOrientation.DOWN, SpriteManager.ESprite.PACDOWN);
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.PACNEUTRAL);
            pos = new Vector2(113, 92);
            sp = new Sprite(pos, ortToSp[orientation]);
        }
    }
}
