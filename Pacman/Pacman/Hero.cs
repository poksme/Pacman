using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Hero
    {
        private Vector2 pos;
        public Sprite sp;
        private TimeSpan TotalElapsed;
        private TimeSpan TimePerFrame;

        public Hero()
        {
            pos = new Vector2(100, 100);
            sp = new Sprite(pos, SpriteManager.ESprite.PACNEUTRAL);
            TotalElapsed = new TimeSpan();
            TimePerFrame = new TimeSpan(1000000);
        }

        public void update(GameTime gt)
        {
            TotalElapsed += gt.ElapsedGameTime;
            if (TotalElapsed > TimePerFrame)
            {
                sp.step = (sp.step + 1) % 2;
                TotalElapsed -= TimePerFrame;
            }
            sp.drawn = false;
        }
    }
}
