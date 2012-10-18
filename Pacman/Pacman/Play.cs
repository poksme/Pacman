using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace Pacman
{
    class Play : AScene
    {
        private LevelManager levelManager_;
        private Hero hero_;
        private AEnnemy[] monsters_;
        private Dictionary<ACharacter.EOrientation, ButtonState> directionsToDPad_;

        public Play(SceneManager sm, SpriteManager spm, SoundManager som)
            : base(sm, spm, som)
        {
            load();
        }

        public override void load()
        {
            lastState = GamePad.GetState(PlayerIndex.One);
            levelManager_ = new LevelManager();
            directionsToDPad_ = new Dictionary<ACharacter.EOrientation, ButtonState>();
            directionsToDPad_.Add(ACharacter.EOrientation.UP, ButtonState.Released);
            directionsToDPad_.Add(ACharacter.EOrientation.DOWN, ButtonState.Released);
            directionsToDPad_.Add(ACharacter.EOrientation.LEFT, ButtonState.Released);
            directionsToDPad_.Add(ACharacter.EOrientation.RIGHT, ButtonState.Released);
            hero_ = new Hero(spm_);
            monsters_ = new AEnnemy[] {
                new Blinky(spm_),
                new Inky(spm_),
                new Clyde(spm_),
                new Pinky(spm_)
            };
            monsters_[0].setBlocked(false);
        }

        private void move()
        {
            directionsToDPad_[ACharacter.EOrientation.UP] = currentState.DPad.Up;
            directionsToDPad_[ACharacter.EOrientation.DOWN] = currentState.DPad.Down;
            directionsToDPad_[ACharacter.EOrientation.LEFT] = currentState.DPad.Left;
            directionsToDPad_[ACharacter.EOrientation.RIGHT] = currentState.DPad.Right;
            foreach (var pair in directionsToDPad_)
            {
                if (pair.Value == ButtonState.Pressed || hero_.getOrientation() == pair.Key)
                {
                    if (levelManager_.directionFree(hero_.getX(), hero_.getY(), pair.Key))
                    {
                        hero_.setOrientation(pair.Key);
                        if (levelManager_.pixelPowerEat(hero_.getX(), hero_.getY()))
                        {
                            hero_.setPowerUp();
                            som_.play(SoundManager.ESound.PAUSE, 0.5f);
                        }
                        else if (levelManager_.pixelEat(hero_.getX(), hero_.getY()))
                        {
                            hero_.eatPallet();
                            som_.play(SoundManager.ESound.CHOMP, -0.9f, 0.2f);
                        }
                        hero_.setBlocked(false);
                    }
                    else if (hero_.getOrientation() == pair.Key)
                        hero_.setBlocked(true);

                }
            }
        }

        public override void activate()
        {
            base.activate();
            som_.stopPlaying();
            som_.bgmPlay();
        }

        public override void desactivate()
        {
            base.desactivate();
            som_.bgmPause();
        }

        public override void update(GameTime gt)
        {
            currentState = GamePad.GetState(PlayerIndex.One);
            if (currentState.IsConnected)
            {
                #region BUTTONSTATE
                if (currentState.Buttons.A == ButtonState.Pressed)
                    spm_.zoomOut();
                if (currentState.Buttons.B == ButtonState.Pressed)
                    spm_.zoomIn();
                if (currentState.Buttons.Y == ButtonState.Pressed && lastState.Buttons.Y == ButtonState.Released)
                    spm_.toggleCentering();
                #endregion
                if (currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.activateScene(SceneManager.EScene.PAUSE);
                }

                move();
            }
            lastState = currentState;

            hero_.update(gt);
            if (hero_.poweredUp())
                som_.setBgmPitch(0.5f);
            else
                som_.setBgmPitch(0.1f);
            if (hero_.getOrientation() != ACharacter.EOrientation.NEUTRAL)
            foreach (AEnnemy m in monsters_)
            {
                if (hero_.poweredUpEnding() && !m.isDead())
                    m.setState(AEnnemy.EState.FRIGHTEN_ENDING);
                else if (hero_.poweredUp() && !m.isDead())
                    m.setState(AEnnemy.EState.FRIGHTEN);
                else if (!m.isDead())
                    m.setState(AEnnemy.EState.ALIVE);
                if (levelManager_.directionFree(m.getX(), m.getY(), m.getOrientation()))
                    m.setBlocked(false);
                else
                    m.setBlocked(true);
                if (m.isTouching(hero_))
                {
                    if (hero_.poweredUp())
                    {
                        if (!m.isDead())
                        {
                            m.setState(AEnnemy.EState.DEAD);
                            som_.play(SoundManager.ESound.EATGHOST, 0, 0.3f);
                            hero_.addBonus(1000);
                        }
                    }
                    else if (!m.isDead())
                    {
                        scm_.desactivateAll();
                        scm_.activateScene(SceneManager.EScene.TITLE);
                    }
                }
                levelManager_.setFreeDirections(m);
                    m.setIntersection(levelManager_.intersection(m.getX(), m.getY(), m.getOrientation()));
                    m.setDestination(levelManager_.getPacManDirection(hero_, m));
            
                m.update(gt);
            }
            spm_.updateHeroPosition(hero_);
            if (hero_.won())
            {
                scm_.desactivateAll();
                scm_.activateScene(SceneManager.EScene.WIN);
            }
        }

        private void drawMap()
        {
            spm_.drawBackground();
            for (uint i = 0; i < levelManager_.getHeight(); ++i)
                for (uint j = 0; j < levelManager_.getWidth(); ++j)
                {
                    if (levelManager_.isPix(j, i))
                        spm_.drawMapScaled(j, i, SpriteManager.ESprite.PALLET);
                    else if (levelManager_.isPallet(j, i))
                        spm_.drawMapScaled(j, i, SpriteManager.ESprite.POWERPALLET);
                }
        }

        public override void draw()
        {
            drawMap();

            #region BUTTONDRAW
            //spm_.drawSprite(A);
            //spm_.drawSprite(B);
            //spm_.drawSprite(X);
            //spm_.drawSprite(Y);
            #endregion
            hero_.draw();
            foreach (ACharacter m in monsters_)
                m.draw();
        }

        public override void unload()
        {
            spm_.zoomScaleInit();
        }
        public int getBonus()
        {
            return hero_.getBonus();
        }
    }
}
