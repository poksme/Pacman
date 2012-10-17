using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    abstract class ACharacter
    {
        public enum EOrientation { UP, DOWN, LEFT, RIGHT, NEUTRAL}
        protected EOrientation orientation;
        protected Vector2 pos;
        public Sprite sp;
        protected TimeSpan TotalElapsed;
        protected TimeSpan TimePerFrame;
        protected Dictionary<ACharacter.EOrientation, SpriteManager.ESprite> ortToSp;
        protected Boolean blocked;
        protected Rectangle hitBox;
        private SpriteManager spm;
        protected bool intersection;
        protected EOrientation destination;
        bool dead;

        public ACharacter(SpriteManager s)
        {
            orientation = EOrientation.NEUTRAL;
            TotalElapsed = new TimeSpan();
            TimePerFrame = new TimeSpan(1000000);
            blocked = true;
            ortToSp = new Dictionary<EOrientation, SpriteManager.ESprite>();
            spm = s;
            intersection = false;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, 16, 16);
            destination = EOrientation.UP;
            dead = false;
        }

        public void setOrientation(EOrientation ort)
        {
            orientation = ort;
        }

        public EOrientation getOrientation()
        {
            return orientation;
        }

        private void animate(GameTime gt)
        {
            TotalElapsed += gt.ElapsedGameTime;
            if (TotalElapsed > TimePerFrame)
            {
                sp.step = (sp.step + 1) % 2;
                TotalElapsed -= TimePerFrame;
            }
        }

        public float getX()
        {
            return pos.X;
        }
        public float getY()
        {
            return pos.Y;
        }

        public void setBlocked(Boolean b)
        {
            blocked = b;
        }

        virtual public void draw()
        {
            sp.pos.X = pos.X - 8;
            sp.pos.Y = pos.Y + 16;
            sp.drawn = false;
            spm.drawSprite(sp);
        }

        virtual public void update(GameTime gt)
        {
            if (!blocked)
            {
                if (!dead)
                    sp.id = ortToSp[orientation];
                switch (orientation)
                {
                    case (EOrientation.LEFT):
                        if (dead)
                            sp.id = SpriteManager.ESprite.EYES_LEFT;
                        if ((pos.X = pos.X - 1) < 0)
                            pos.X = 220;
                        break;
                    case (EOrientation.RIGHT):
                        if (dead)
                            sp.id = SpriteManager.ESprite.EYES_RIGHT;
                        pos.X = (pos.X + 1) % 220;
                        break;
                    case (EOrientation.UP):
                        if (dead)
                            sp.id = SpriteManager.ESprite.EYES_UP;
                        pos.Y = pos.Y - 1;
                        break;
                    case (EOrientation.DOWN):
                        if (dead)
                            sp.id = SpriteManager.ESprite.EYES_DOWN;
                        pos.Y = pos.Y + 1;
                        break;
                    default:
                        break;
                }
                animate(gt);
            }
            hitBox.X = (int)pos.X;
            hitBox.Y = (int)pos.Y;
        }

        public Boolean touches(ACharacter o)
        {
            return hitBox.Intersects(o.hitBox);
        }

        internal void setIntersection(bool p)
        {
            intersection = p;
        }

        internal void setDirection(EOrientation eOrientation)
        {
            destination = eOrientation;
        }

        public void setDead()
        {
            dead = true;
        }

        internal bool isDead()
        {
            return dead;
        }
    }
}
