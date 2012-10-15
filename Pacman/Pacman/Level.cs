using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Level : AScene
    {
        public enum EBlocks {PIX, DOOR, WALL, ENNEMY, SPAWN, EMPTY, PALLETS };
        private uint lvl;
        private LevelManager lm;
        private Sprite A;
        private Sprite B;
        private Sprite X;
        private Sprite Y;
        private Hero h;

        public Level(SceneManager sm, SpriteManager spm, uint level) : base(sm, spm)
        {
            lastState = GamePad.GetState(PlayerIndex.One);
            lvl = level;
            lm = new LevelManager();
            A = new Sprite(new Vector2(200, 200), SpriteManager.ESprite.A);
            B = new Sprite(new Vector2(220, 200), SpriteManager.ESprite.B);
            X = new Sprite(new Vector2(240, 200), SpriteManager.ESprite.X);
            Y = new Sprite(new Vector2(260, 200), SpriteManager.ESprite.Y);
            h = new Hero(Character.EOrientation.NEUTRAL);
        }
        public void setLevel(uint level)
        {
            lvl = level;
        }

        public override void load()
        {

        }

        public override void update(GameTime gt)
        {
            h.update(gt);

            currentState = GamePad.GetState(PlayerIndex.One);

            if (currentState.IsConnected)
            {
                if (currentState.Buttons.A == ButtonState.Pressed)
                {
                    A.drawn = false;
                    spm_.zoomOut();
                }
                if (currentState.Buttons.B == ButtonState.Pressed)
                {
                    B.drawn = false;
                    spm_.zoomIn();
                }
                if (currentState.Buttons.X == ButtonState.Pressed)
                {
                    X.drawn = false;
                }
                if (currentState.Buttons.Y == ButtonState.Pressed)
                {
                    Y.drawn = false;
                }
                if (currentState.Buttons.Start == ButtonState.Pressed && lastState.Buttons.Start == ButtonState.Released)
                {
                    scm_.setScene(SceneManager.EScene.PAUSE);
                }


                if (currentState.DPad.Left == ButtonState.Pressed || h.getOrientation() == Character.EOrientation.LEFT)
                {
                    if (!lm.pixelIsWall(h.getX() - 5, h.getY()) &&
                        !lm.pixelIsWall(h.getX() - 5, h.getY() - 3) &&
                        !lm.pixelIsWall(h.getX() - 5, h.getY() + 3))
                    {
                    h.setOrientation(Character.EOrientation.LEFT);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == Character.EOrientation.LEFT)
                        h.setBlocked(true);
                }
                if (currentState.DPad.Right == ButtonState.Pressed || h.getOrientation() == Character.EOrientation.RIGHT)
                {
                    if (!lm.pixelIsWall(h.getX() + 5, h.getY()) && 
                        !lm.pixelIsWall(h.getX() + 5, h.getY() + 3) && 
                        !lm.pixelIsWall(h.getX() + 5, h.getY() - 3))
                    {
                    h.setOrientation(Character.EOrientation.RIGHT);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == Character.EOrientation.RIGHT)
                        h.setBlocked(true);
                }
                if (currentState.DPad.Up == ButtonState.Pressed || h.getOrientation() == Character.EOrientation.UP)
                {
                    if (!lm.pixelIsWall(h.getX(), h.getY() - 5) &&
                        !lm.pixelIsWall(h.getX() - 3, h.getY() - 5) &&
                        !lm.pixelIsWall(h.getX() + 3, h.getY() - 5))
                    {
                    h.setOrientation(Character.EOrientation.UP);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == Character.EOrientation.UP)
                        h.setBlocked(true);
                }
                if (currentState.DPad.Down == ButtonState.Pressed || h.getOrientation() == Character.EOrientation.DOWN)
                {
                    if (!lm.pixelIsWall(h.getX(), h.getY() + 5) &&
                        !lm.pixelIsWall(h.getX() + 3, h.getY() + 5) &&
                        !lm.pixelIsWall(h.getX() - 3, h.getY() + 5))
                    {
                    h.setOrientation(Character.EOrientation.DOWN);
                    lm.pixelEat(h.getX(), h.getY());
                    h.setBlocked(false);
                    }
                    else if (h.getOrientation() == Character.EOrientation.DOWN)
                        h.setBlocked(true);
                }
                //// Update previous gamepad state.
                //previousGamePadState = currentState;
            }
            lastState = currentState;
        }
        private void drawMap()
        {
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
            spm_.drawBackground();
            drawMap();
            spm_.drawSprite(A);
            spm_.drawSprite(B);
            spm_.drawSprite(X);
            spm_.drawSprite(Y);
            spm_.drawSprite(h.sp);
        }

        public override void unload()
        {

        }
    }
}
