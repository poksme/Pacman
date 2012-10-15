using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    abstract class Character
    {
        public enum EOrientation { UP, DOWN, LEFT, RIGHT, NEUTRAL}
        protected EOrientation orientation;
        protected Vector2 pos;
        public Sprite sp;
        protected TimeSpan TotalElapsed;
        protected TimeSpan TimePerFrame;
        protected Dictionary<Character.EOrientation, SpriteManager.ESprite> ortToSp;

        public Character(EOrientation ort)
        {
            orientation = ort;
            TotalElapsed = new TimeSpan();
            TimePerFrame = new TimeSpan(1000000);
        }

        public void setOrientation(EOrientation ort)
        {
            orientation = ort;
        }

        public EOrientation getOrientation()
        {
            return orientation;
        }

        protected void animate(GameTime gt)
        {
            TotalElapsed += gt.ElapsedGameTime;
            if (TotalElapsed > TimePerFrame)
            {
                sp.step = (sp.step + 1) % 2;
                TotalElapsed -= TimePerFrame;
            }
        }
        protected void draw()
        {
            sp.pos.X = pos.X- 8;
            sp.pos.Y = pos.Y + 16;
            sp.drawn = false;
        }

        public float getX()
        {
            return pos.X;
        }
        public float getY()
        {
            return pos.Y;
        }
    }
}
