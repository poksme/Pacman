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
        public enum EBlocks {PIX, DOOR, WALL, ENNEMY, SPAWN, EMPTY, PALLETS };
        private LevelManager lm;

        #region BUTTON DECLARATION
        //private Sprite A;
        //private Sprite B;
        //private Sprite X;
        //private Sprite Y;
        #endregion
        private Hero h;
        private ACharacter[] monsters;

        public Play(SceneManager sm, SpriteManager spm) : base(sm, spm)
        {
            lastState = GamePad.GetState(PlayerIndex.One);
            lm = new LevelManager();

            #region BUTTONS
            //A = new Sprite(new Vector2(200, 200), SpriteManager.ESprite.A);
            //B = new Sprite(new Vector2(220, 200), SpriteManager.ESprite.B);
            //X = new Sprite(new Vector2(240, 200), SpriteManager.ESprite.X);
            //Y = new Sprite(new Vector2(260, 200), SpriteManager.ESprite.Y);
            #endregion
            h = new Hero(spm);
            monsters = new ACharacter[] {
                new Blinky(spm)
            };
            monsters[0].setBlocked(false);
        }

        public override void load()
        {

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
                //if (currentState.Buttons.Y == ButtonState.Pressed)
                //{
                //    Y.drawn = false;
                //}
                #endregion
                if (currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    scm_.desactivateAll();
                    scm_.activateScene(SceneManager.EScene.PAUSE);
                }


                if (currentState.DPad.Left == ButtonState.Pressed || h.getOrientation() == ACharacter.EOrientation.LEFT)
                {
                    if (lm.directionFree(h.getX(), h.getY(), ACharacter.EOrientation.LEFT))
                    {
                    h.setOrientation(ACharacter.EOrientation.LEFT);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == ACharacter.EOrientation.LEFT)
                        h.setBlocked(true);
                }
                if (currentState.DPad.Right == ButtonState.Pressed || h.getOrientation() == ACharacter.EOrientation.RIGHT)
                {
                    if (lm.directionFree(h.getX(), h.getY(), ACharacter.EOrientation.RIGHT))
                    {
                    h.setOrientation(ACharacter.EOrientation.RIGHT);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == ACharacter.EOrientation.RIGHT)
                        h.setBlocked(true);
                }
                if (currentState.DPad.Up == ButtonState.Pressed || h.getOrientation() == ACharacter.EOrientation.UP)
                {
                    if (lm.directionFree(h.getX(), h.getY(), ACharacter.EOrientation.UP))
                    {
                    h.setOrientation(ACharacter.EOrientation.UP);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == ACharacter.EOrientation.UP)
                        h.setBlocked(true);
                }
                if (currentState.DPad.Down == ButtonState.Pressed || h.getOrientation() == ACharacter.EOrientation.DOWN)
                {
                    if (lm.directionFree(h.getX(), h.getY(), ACharacter.EOrientation.DOWN))
                    {
                    h.setOrientation(ACharacter.EOrientation.DOWN);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == ACharacter.EOrientation.DOWN)
                        h.setBlocked(true);
                }
            }
            lastState = currentState;

            h.update(gt);
            foreach (ACharacter m in monsters)
            {
                if (lm.directionFree(m.getX(), m.getY(), m.getOrientation()))
                    m.setBlocked(false);
                else
                    m.setBlocked(true);
                m.update(gt);
            }
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

        }
    }
}
