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
            h = new Hero();
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
                }
                if (currentState.Buttons.B == ButtonState.Pressed)
                {
                    B.drawn = false;
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
                if (currentState.DPad.Left == ButtonState.Pressed)
                {
                    h.sp.id = SpriteManager.ESprite.PACLEFT;
                }
                if (currentState.DPad.Right == ButtonState.Pressed)
                {
                    h.sp.id = SpriteManager.ESprite.PACRIGHT;
                }
                if (currentState.DPad.Up == ButtonState.Pressed)
                {
                    h.sp.id = SpriteManager.ESprite.PACUP;
                }
                if (currentState.DPad.Down == ButtonState.Pressed)
                {
                    h.sp.id = SpriteManager.ESprite.PACDOWN;
                }
                //// Update previous gamepad state.
                //previousGamePadState = currentState;
            }
            lastState = currentState;
        }
        private void drawMap()
        {
            for (uint i = 0; i < lm.getLevelHeight(lvl); ++i)
                for (uint j = 0; j < lm.getLevelWidth(lvl); ++j)
                {
                    if (lm.getBlock(lvl, j, i) == EBlocks.PIX)
                        spm_.drawAtIt(j, i, SpriteManager.ESprite.PIX);
                    else if (lm.getBlock(lvl, j, i) == EBlocks.PALLETS)
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
