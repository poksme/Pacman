using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    abstract class AEnnemy : ACharacter
    {
        public enum EState { ALIVE, DEAD, DEAD_ENDING, FRIGHTEN, FRIGHTEN_ENDING }
        protected EState state_;
        protected TimeSpan deadTimer_;
        protected Dictionary<Tuple<EState, ACharacter.EOrientation>, SpriteManager.ESprite> stateOrientationToSprite_;
        protected Random random_;
        protected Dictionary<EOrientation, bool> freePath_;

        public AEnnemy(SpriteManager s, EOrientation e) :
            base(s, e)
        {
            state_ = EState.ALIVE;

            deadTimer_ = TimeSpan.Zero;

            random_ = new Random();

            freePath_ = new Dictionary<EOrientation, bool>();

            freePath_.Add(EOrientation.DOWN, false);
            freePath_.Add(EOrientation.UP, false);
            freePath_.Add(EOrientation.RIGHT, false);
            freePath_.Add(EOrientation.LEFT, false);
            freePath_.Add(EOrientation.NEUTRAL, false);

            stateOrientationToSprite_ = new Dictionary<Tuple<EState, EOrientation>, SpriteManager.ESprite>();

            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD, ACharacter.EOrientation.UP), SpriteManager.ESprite.EYESUP);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD, ACharacter.EOrientation.DOWN), SpriteManager.ESprite.EYESDOWN);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD, ACharacter.EOrientation.LEFT), SpriteManager.ESprite.EYESLEFT);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD, ACharacter.EOrientation.RIGHT), SpriteManager.ESprite.EYESRIGHT);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD, ACharacter.EOrientation.NEUTRAL), SpriteManager.ESprite.EYESDOWN);

            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD_ENDING, ACharacter.EOrientation.UP), SpriteManager.ESprite.DEADENDINGUP);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD_ENDING, ACharacter.EOrientation.DOWN), SpriteManager.ESprite.DEADENDINGDOWN);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD_ENDING, ACharacter.EOrientation.LEFT), SpriteManager.ESprite.DEADENDINGLEFT);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD_ENDING, ACharacter.EOrientation.RIGHT), SpriteManager.ESprite.DEADENDINGRIGHT);
            stateOrientationToSprite_.Add(Tuple.Create(EState.DEAD_ENDING, ACharacter.EOrientation.NEUTRAL), SpriteManager.ESprite.DEADENDINGDOWN);
        }
        abstract public void IA();
        public override void update(Microsoft.Xna.Framework.GameTime gt)
        {
            base.update(gt);
                if (state_ == EState.FRIGHTEN)
                    sprite_.id = SpriteManager.ESprite.FRIGHTGHOST;
                else if (state_ == EState.FRIGHTEN_ENDING)
                    sprite_.id = SpriteManager.ESprite.FRIGHTENDING;
                else if (state_ != EState.ALIVE)
                    sprite_.id = stateOrientationToSprite_[Tuple.Create(state_, base.orientation_)];
            IA();
            deadTimer_ -= elapsedTime_;
            if (deadTimer_ <= TimeSpan.Zero)
                state_ = EState.ALIVE;
            else if (deadTimer_ <= new TimeSpan(0, 0, 5))
                state_ = EState.DEAD_ENDING;
        }
        public override void draw()
        {
            base.draw();
        }
        public void setState(EState e)
        {
            state_ = e;
            if (e == EState.DEAD)
                deadTimer_ = new TimeSpan(0, 0, 15);
        }
        public bool isState(EState e)
        {
            return state_ == e;
        }
        public bool isDead()
        {
            return (state_ == EState.DEAD || state_ == EState.DEAD_ENDING);
        }

        public void setFreePath(EOrientation e)
        {
            freePath_[e] = true;
        }
        public void resetFreePath()
        {
            foreach (EOrientation e in Enum.GetValues(typeof(EOrientation)))
                freePath_[e] = false;
        }
    }
}
