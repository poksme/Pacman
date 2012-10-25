using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    abstract class ACharacter
    {
        #region DECLARATIONS
        public enum EOrientation { UP, DOWN, LEFT, RIGHT, NEUTRAL}

        private SpriteManager spriteManager_;
        
        protected EOrientation orientation_;
        protected EOrientation destination_;
        protected Vector2 position_;

        protected Sprite sprite_;

        protected TimeSpan totalElapsedTime_;
        protected TimeSpan elapsedTime_;
        protected TimeSpan timePerFrame_;

        protected Rectangle hitBox_;

        protected bool atIntersection_;
        protected bool blocked_;

        private float speedPerSec_;

        protected Dictionary<ACharacter.EOrientation, SpriteManager.ESprite> orientationToSprite_;
        #endregion

        public ACharacter(SpriteManager s, EOrientation e)
        {
            orientation_ = EOrientation.NEUTRAL;
            totalElapsedTime_ = new TimeSpan();
            timePerFrame_ = new TimeSpan(1000000);
            blocked_ = true;
            orientationToSprite_ = new Dictionary<EOrientation, SpriteManager.ESprite>();
            spriteManager_ = s;
            atIntersection_ = false;
            hitBox_ = new Rectangle((int)position_.X + 4, (int)position_.Y + 4, 8, 8);
            destination_ = e;
            speedPerSec_ = 60;
        }
        virtual public void update(GameTime gt)
        {
            float padding;

            padding = speedPerSec_ * (float)elapsedTime_.TotalSeconds;
            if (!blocked_)
            {
                switch (orientation_)
                {
                    case (EOrientation.LEFT):
                        if ((position_.X = position_.X - padding) < 0)
                            position_.X = 220;
                        break;
                    case (EOrientation.RIGHT):
                        position_.X = (position_.X + padding) % 220;
                        break;
                    case (EOrientation.UP):
                        position_.Y = position_.Y - padding;
                        break;
                    case (EOrientation.DOWN):
                        position_.Y = position_.Y + padding;
                        break;
                    default:
                        break;
                }
            }
            sprite_.id = orientationToSprite_[orientation_];
            if (!((this is Hero) && blocked_))
                animate(gt);
            hitBox_.X = (int)position_.X + 4;
            hitBox_.Y = (int)position_.Y + 4;
        }
        virtual public void draw()
        {
            sprite_.pos.X = position_.X - 8;
            sprite_.pos.Y = position_.Y + 16;
            sprite_.drawn = false;
            spriteManager_.drawSpriteScreenScaled(sprite_);
        }

        private void animate(GameTime gt)
        {
            elapsedTime_ = gt.ElapsedGameTime;
            totalElapsedTime_ += elapsedTime_;
            if (totalElapsedTime_ > timePerFrame_)
            {
                sprite_.step = (sprite_.step + 1) % 2;
                totalElapsedTime_ -= timePerFrame_;
            }
        }
        public void setOrientation(EOrientation ort)
        {
            orientation_ = ort;
        }
        public EOrientation getOrientation()
        {
            return orientation_;
        }
        public float getX()
        {
            return position_.X;
        }
        public float getY()
        {
            return position_.Y;
        }
        public void setBlocked(Boolean b)
        {
            blocked_ = b;
        }
        public bool isTouching(ACharacter o)
        {
            return hitBox_.Intersects(o.hitBox_);
        }
        public void setIntersection(bool p)
        {
            atIntersection_ = p;
        }
        public void setDestination(EOrientation eOrientation)
        {
            destination_ = eOrientation;
        }
    }
}
