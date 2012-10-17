using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Play : AScene
    {
        //LEVEL
        private LevelManager lm;

        //CHARACTERS
        private Hero h;
        private ACharacter[] monsters;

        //DIRECTIONNAL INPUTS
        private Dictionary<ACharacter.EOrientation, ButtonState> directions;

        public Play(SceneManager sm, SpriteManager spm) : base(sm, spm)
        {
            load();
        }

        public override void load()
        {
            lastState = GamePad.GetState(PlayerIndex.One);
            lm = new LevelManager();
            directions = new Dictionary<ACharacter.EOrientation, ButtonState>();
            directions.Add(ACharacter.EOrientation.UP, ButtonState.Released);
            directions.Add(ACharacter.EOrientation.DOWN, ButtonState.Released);
            directions.Add(ACharacter.EOrientation.LEFT, ButtonState.Released);
            directions.Add(ACharacter.EOrientation.RIGHT, ButtonState.Released);
            h = new Hero(spm_);
            monsters = new ACharacter[] {
                new Blinky(spm_),
                new Inky(spm_),
                new Clyde(spm_),
                new Pinky(spm_)
            };
            monsters[0].setBlocked(false);
        }

        private void move()
        {
            directions[ACharacter.EOrientation.UP] = currentState.DPad.Up;
            directions[ACharacter.EOrientation.DOWN] = currentState.DPad.Down;
            directions[ACharacter.EOrientation.LEFT] = currentState.DPad.Left;
            directions[ACharacter.EOrientation.RIGHT] = currentState.DPad.Right;
            foreach (var pair in directions)
            {
                if (pair.Value == ButtonState.Pressed || h.getOrientation() == pair.Key)
                {
                    if (lm.directionFree(h.getX(), h.getY(), pair.Key))
                    {
                        h.setOrientation(pair.Key);
                        if (lm.pixelPowerEat(h.getX(), h.getY()))
                            h.setPowerUp();
                        else if (lm.pixelEat(h.getX(), h.getY()))
                            h.addBonus();
                        h.setBlocked(false);
                    }
                    else if (h.getOrientation() == pair.Key)
                        h.setBlocked(true);

                }
            }
        }

        public override void update(GameTime gt)
        {
            currentState = GamePad.GetState(PlayerIndex.One);

            if (currentState.IsConnected)
            {
                #region BUTTONSTATE
                if (currentState.Buttons.A == ButtonState.Pressed)
                {
                    //A.drawn = false;
                    spm_.zoomOut();
                }
                if (currentState.Buttons.B == ButtonState.Pressed)
                {
                    //B.drawn = false;
                    spm_.zoomIn();
                }
                //if (currentState.Buttons.X == ButtonState.Pressed)
                //{
                //    X.drawn = false;
                //}
                if (currentState.Buttons.Y == ButtonState.Pressed && lastState.Buttons.Y == ButtonState.Released)
                {
                    spm_.toggleFollow();
                }
                #endregion
                if (currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.activateScene(SceneManager.EScene.PAUSE);
                }

                move();
            }
            lastState = currentState;

            h.update(gt);
            foreach (ACharacter m in monsters)
            {
                if (h.poweredUpEnding() && !m.isDead())
                    m.setState(ACharacter.EState.FRIGHTEN_ENDING);
                else if (h.poweredUp() && !m.isDead())
                    m.setState(ACharacter.EState.FRIGHTEN);
                else if (!m.isDead())
                    m.setState(ACharacter.EState.ALIVE);
                if (lm.directionFree(m.getX(), m.getY(), m.getOrientation()))
                    m.setBlocked(false);
                else
                    m.setBlocked(true);
                if (m.touches(h))
                {
                    if (h.poweredUp())
                        m.setState(ACharacter.EState.DEAD);
                    else if (!m.isDead())
                    {
                        scm_.desactivateAll();
                        scm_.activateScene(SceneManager.EScene.TITLE);
                    }
                }
                    m.setIntersection(lm.intersection(m.getX(), m.getY(), m.getOrientation()));
                    m.setDirection(lm.getPacManDirection(h, m));
            
                m.update(gt);
            }
            spm_.update(h);
        }

        private void drawMap()
        {
            spm_.drawBackground();
            for (uint i = 0; i < lm.getHeight(); ++i)
                for (uint j = 0; j < lm.getWidth(); ++j)
                {
                    if (lm.isPix(j, i))
                        spm_.drawAtIt(j, i, SpriteManager.ESprite.PIX);
                    else if (lm.isPallet(j, i))
                        spm_.drawAtIt(j, i, SpriteManager.ESprite.PALLETS);
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
            h.draw();
            foreach (ACharacter m in monsters)
                m.draw();
        }

        public override void unload()
        {
            spm_.scaleInit();
        }
        public int getBonus()
        {
            return h.getBonus();
        }
    }
}
