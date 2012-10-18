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
        private int pix = 0;
        private int bonus = 0;
        public Hero(SpriteManager s):base(s, EOrientation.NEUTRAL)
        {
            orientationToSprite_.Add(EOrientation.LEFT, SpriteManager.ESprite.PACLEFT);
            orientationToSprite_.Add(EOrientation.RIGHT, SpriteManager.ESprite.PACRIGHT);
            orientationToSprite_.Add(EOrientation.UP, SpriteManager.ESprite.PACUP);
            orientationToSprite_.Add(EOrientation.DOWN, SpriteManager.ESprite.PACDOWN);
            orientationToSprite_.Add(EOrientation.NEUTRAL, SpriteManager.ESprite.PACNEUTRAL);
            position_ = new Vector2(113, 92);
            sprite_ = new Sprite(position_, orientationToSprite_[orientation_]);
            power = new TimeSpan(0);
        }

        public bool poweredUp()
        {          
            return (power.Ticks > 0);
        }

        public void setPowerUp()
        {
            power = new TimeSpan(0, 0, 6);
            bonus += 500;
        }

        public override void update(GameTime gt)
        {
            base.update(gt);
            power -= elapsedTime_;
        }

        public override void draw()
        {
            base.draw();
        }

        public void addBonus(int b = 100)
        {
            bonus += b;
        }

        internal void eatPallet()
        {
            addBonus();
            pix += 1;
        }
        public int getBonus()
        {
            return bonus;
        }
        public bool won()
        {
            return (pix >= 240);
        }

        internal bool poweredUpEnding()
        {
            return (power < new TimeSpan(0, 0, 2) && power > TimeSpan.Zero);
        }
    }
}
