using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Hero : ACharacter
    {
        private TimeSpan power;
        public Hero(SpriteManager s):base(s)
        {
            ortToSp.Add(EOrientation.LEFT, SpriteManager.ESprite.PACLEFT);
            ortToSp.Add(EOrientation.RIGHT, SpriteManager.ESprite.PACRIGHT);
            ortToSp.Add(EOrientation.UP, SpriteManager.ESprite.PACUP);
            ortToSp.Add(EOrientation.DOWN, SpriteManager.ESprite.PACDOWN);
            ortToSp.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.PACNEUTRAL);
            pos = new Vector2(113, 92);
            sp = new Sprite(pos, ortToSp[orientation]);
            power = new TimeSpan(0);
        }

        public bool poweredUp()
        {
            return (power.Ticks > 0);
        }

        public void setPowerUp()
        {
            power = new TimeSpan(0, 0, 6);
        }

        public override void update(GameTime gt)
        {
            base.update(gt);
            power -= gt.ElapsedGameTime;
        }
    }
}
