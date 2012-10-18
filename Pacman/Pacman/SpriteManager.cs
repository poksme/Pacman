using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Pacman
{
    class SpriteManager
    {
        #region DECLARATIONS
        private SpriteBatch spriteBatch_;
        private GraphicsDevice graphicsDevice_;
        private ContentManager contentManager_;

        private Texture2D spriteTex_;
        private Dictionary<SpriteManager.ESprite, Rectangle[]> spriteRec_;

        private Texture2D fontTex_;
        private Dictionary<char, Rectangle> fontRec_;
        
        private Texture2D backgroundTex_;
        private Rectangle backgroundRec_;

        private Texture2D blackTex_;
        private Rectangle blackRec_;

        private Texture2D titleTex_;
        private Rectangle titleRec_;

        private bool heroCentered_;
        private Vector2 heroPos_ = Vector2.Zero;

        private Vector2 tmpPos_ = Vector2.Zero;
        private float zoomScale_ = 2f;

        public enum ESprite { 
            PACUP, PACDOWN, PACLEFT, PACRIGHT, PACNEUTRAL, 
            PALLET, POWERPALLET, A, B, X, Y, START, 
            EYESLEFT, EYESRIGHT, EYESDOWN, EYESUP,
            BLINKYUP, BLINKYDOWN, BLINKYLEFT, BLINKYRIGHT, 
            FRIGHTGHOST, FRIGHTENDING,
            DEADENDINGUP, DEADENDINGDOWN, DEADENDINGLEFT, DEADENDINGRIGHT,
            INKYUP, INKYDOWN, INKYLEFT, INKYRIGHT,
            CLYDEUP, CLYDEDOWN, CLYDELEFT, CLYDERIGHT,
            PINKYUP, PINKYDOWN, PINKYLEFT, PINKYRIGHT };
        #endregion

        public SpriteManager(SpriteBatch spriteBatch, ContentManager contentManager, GraphicsDevice graphicsDevice)
        {
            spriteBatch_ = spriteBatch;
            contentManager_ = contentManager;
            graphicsDevice_ = graphicsDevice;

            spriteTex_ = contentManager_.Load<Texture2D>("sprite_sheet");
            fontTex_ = contentManager_.Load<Texture2D>("pixelfont");
            backgroundTex_ = contentManager_.Load<Texture2D>("background");
            titleTex_ = contentManager_.Load<Texture2D>("Title");

            spriteRec_ = new Dictionary<SpriteManager.ESprite, Rectangle[]>();
            fontRec_ = new Dictionary<char, Rectangle>();

            heroCentered_ = false;

            blackTex_ = new Texture2D(graphicsDevice, 1, 1);
            blackTex_.SetData(new Color[] { new Color(30, 30, 30, 225)  });


            #region RECTANGLES DEFINITIONS
            #region CHARACTERS
            spriteRec_.Add(SpriteManager.ESprite.PACNEUTRAL, new Rectangle[] { new Rectangle(42, 2, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.PACLEFT, new Rectangle[] { new Rectangle(2, 2, 16, 16), new Rectangle(22, 2, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.PACRIGHT, new Rectangle[] { new Rectangle(2, 22, 16, 16), new Rectangle(22, 22, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.PACUP, new Rectangle[] { new Rectangle(2, 42, 16, 16), new Rectangle(22, 42, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.PACDOWN, new Rectangle[] { new Rectangle(2, 62, 16, 16), new Rectangle(22, 62, 16, 16) });

            spriteRec_.Add(SpriteManager.ESprite.BLINKYUP, new Rectangle[] { new Rectangle(2, 82, 16, 16), new Rectangle(22, 82, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.BLINKYDOWN, new Rectangle[] { new Rectangle(42, 82, 16, 16), new Rectangle(62, 82, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.BLINKYLEFT, new Rectangle[] { new Rectangle(82, 82, 16, 16), new Rectangle(102, 82, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.BLINKYRIGHT, new Rectangle[] { new Rectangle(122, 82, 16, 16), new Rectangle(142, 82, 16, 16) });

            spriteRec_.Add(SpriteManager.ESprite.FRIGHTGHOST, new Rectangle[] { new Rectangle(2, 162, 16, 16), new Rectangle(22, 162, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.FRIGHTENDING, new Rectangle[] { new Rectangle(2, 162, 16, 16), new Rectangle(62, 162, 16, 16) });

            spriteRec_.Add(SpriteManager.ESprite.INKYUP, new Rectangle[] { new Rectangle(2, 122, 16, 16), new Rectangle(22, 122, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.INKYDOWN, new Rectangle[] { new Rectangle(42, 122, 16, 16), new Rectangle(62, 122, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.INKYLEFT, new Rectangle[] { new Rectangle(82, 122, 16, 16), new Rectangle(102, 122, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.INKYRIGHT, new Rectangle[] { new Rectangle(122, 122, 16, 16), new Rectangle(142, 122, 16, 16) });

            spriteRec_.Add(SpriteManager.ESprite.CLYDEUP, new Rectangle[] { new Rectangle(2, 142, 16, 16), new Rectangle(22, 142, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.CLYDEDOWN, new Rectangle[] { new Rectangle(42, 142, 16, 16), new Rectangle(62, 142, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.CLYDELEFT, new Rectangle[] { new Rectangle(82, 142, 16, 16), new Rectangle(102, 142, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.CLYDERIGHT, new Rectangle[] { new Rectangle(122, 142, 16, 16), new Rectangle(142, 142, 16, 16) });

            spriteRec_.Add(SpriteManager.ESprite.PINKYUP, new Rectangle[] { new Rectangle(2, 102, 16, 16), new Rectangle(22, 102, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.PINKYDOWN, new Rectangle[] { new Rectangle(42, 102, 16, 16), new Rectangle(62, 102, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.PINKYLEFT, new Rectangle[] { new Rectangle(82, 102, 16, 16), new Rectangle(102, 102, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.PINKYRIGHT, new Rectangle[] { new Rectangle(122, 102, 16, 16), new Rectangle(142, 102, 16, 16) });

            spriteRec_.Add(SpriteManager.ESprite.EYESLEFT, new Rectangle[] { new Rectangle(42, 202, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.EYESRIGHT, new Rectangle[] { new Rectangle(62, 202, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.EYESUP, new Rectangle[] { new Rectangle(2, 202, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.EYESDOWN, new Rectangle[] { new Rectangle(22, 202, 16, 16) });

            spriteRec_.Add(SpriteManager.ESprite.DEADENDINGLEFT, new Rectangle[] { new Rectangle(42, 202, 16, 16), new Rectangle(42, 162, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.DEADENDINGRIGHT, new Rectangle[] { new Rectangle(62, 202, 16, 16), new Rectangle(42, 162, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.DEADENDINGUP, new Rectangle[] { new Rectangle(2, 202, 16, 16), new Rectangle(42, 162, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.DEADENDINGDOWN, new Rectangle[] { new Rectangle(22, 202, 16, 16), new Rectangle(42, 162, 16, 16) });
            #endregion

            #region LOOT
            spriteRec_.Add(SpriteManager.ESprite.PALLET, new Rectangle[] { new Rectangle(42, 22, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.POWERPALLET, new Rectangle[] { new Rectangle(42, 42, 16, 16) });
            #endregion

            #region BUTTONS
            spriteRec_.Add(SpriteManager.ESprite.A, new Rectangle[] { new Rectangle(142, 262, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.B, new Rectangle[] { new Rectangle(162, 262, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.X, new Rectangle[] { new Rectangle(102, 262, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.Y, new Rectangle[] { new Rectangle(122, 262, 16, 16) });
            spriteRec_.Add(SpriteManager.ESprite.START, new Rectangle[] { new Rectangle(182, 262, 16, 16) });
            #endregion

            #region FONT DEFINITION
            char[] tmp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!-".ToCharArray();
            int it = 0;
            foreach (char cr in tmp)
            {
                fontRec_.Add(cr, new Rectangle(it * 8, 7, 8, 7));
                it++;
            }
            tmp = "0123456789() ".ToCharArray();
            it = 0;
            foreach (char cr in tmp)
            {
                fontRec_.Add(cr, new Rectangle(it * 8, 0, 8, 7));
                it++;
            }
            #endregion

            backgroundRec_ = new Rectangle(0, 0, 224, 288);
            blackRec_ = new Rectangle(0, 0, 200, 210);
            titleRec_ = new Rectangle(0, 0, 182, 34);
            #endregion
        }

        public void begin()
        {
            spriteBatch_.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, null);
        }
        public void end()
        {
            spriteBatch_.End();
        }
        public void drawMapScaled(uint x, uint y, SpriteManager.ESprite b)
        {
            if (!heroCentered_)
            {
                tmpPos_.X = (x * 8 - 4) * zoomScale_ + ((graphicsDevice_.Viewport.Width + blackRec_.Width) / 2) - (backgroundRec_.Width / 2) * zoomScale_;
                tmpPos_.Y = (y * 8 + 20) * zoomScale_ + (graphicsDevice_.Viewport.Height / 2) - (backgroundRec_.Height / 2) * zoomScale_;
            }
            else
            {
                tmpPos_.X = (x * 8 - 4) * zoomScale_ + ((graphicsDevice_.Viewport.Width + blackRec_.Width) / 2) - heroPos_.X * zoomScale_;
                tmpPos_.Y = (y * 8 + 20) * zoomScale_ + (graphicsDevice_.Viewport.Height / 2) - heroPos_.Y * zoomScale_;
            }
            spriteBatch_.Draw(spriteTex_, tmpPos_, spriteRec_[b][0], Color.White, 0f, Vector2.Zero, zoomScale_, SpriteEffects.None, 0f);
        }
        public void drawSpriteScreenScaled(Sprite sp)
        {
            if (sp.drawn == false)
            {
                if (!heroCentered_)
                {
                    tmpPos_.X = sp.pos.X * zoomScale_ + ((graphicsDevice_.Viewport.Width + blackRec_.Width) / 2) - (backgroundRec_.Width / 2) * zoomScale_;
                    tmpPos_.Y = sp.pos.Y * zoomScale_ + (graphicsDevice_.Viewport.Height / 2) - (backgroundRec_.Height / 2) * zoomScale_;
                }
                else
                {
                    tmpPos_.X = sp.pos.X * zoomScale_ + ((graphicsDevice_.Viewport.Width + blackRec_.Width) / 2) - heroPos_.X * zoomScale_;
                    tmpPos_.Y = sp.pos.Y * zoomScale_ + (graphicsDevice_.Viewport.Height / 2) - heroPos_.Y * zoomScale_;
                }
                spriteBatch_.Draw(spriteTex_, tmpPos_, spriteRec_[sp.id][Math.Min(sp.step, spriteRec_[sp.id].Length - 1)], Color.White, 0f, Vector2.Zero, zoomScale_, SpriteEffects.None, 0f);
                sp.drawn = true;
            }
        }
        public void zoomIn()
        {
            if (zoomScale_ < 6)
                zoomScale_ *= 1.01f;
            else
                zoomScale_ = 6;
        }
        public void zoomOut()
        {
            if (zoomScale_ > 2)
                zoomScale_ *= 0.99f;
            else
                zoomScale_ = 2;
        }
        public void drawText(String s, Vector2 pos)
        {
            char[] tmp = s.ToUpper().ToCharArray();
            foreach (char c in tmp)
            {
                spriteBatch_.Draw(fontTex_, pos, fontRec_[c], Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
                pos.X += fontRec_[c].Width * 2; 
            }
        }
        public void drawCenteredText(String s, int xOffset = 0, int yOffset = 0)
        {
            drawText(s, new Vector2(graphicsDevice_.Viewport.Width / 2 - (8 * s.Length) + xOffset, graphicsDevice_.Viewport.Height / 2 - 3 + yOffset));
        }
        public void drawBackground()
        {
            if (!heroCentered_)
            {
                tmpPos_.X = ((graphicsDevice_.Viewport.Width + blackRec_.Width) / 2) - (backgroundRec_.Width / 2) * zoomScale_;
                tmpPos_.Y = (graphicsDevice_.Viewport.Height / 2) - (backgroundRec_.Height / 2) * zoomScale_;
            }
            else
            {
                tmpPos_.X = (((graphicsDevice_.Viewport.Width + blackRec_.Width) / 2) - heroPos_.X * zoomScale_);
                tmpPos_.Y = ((graphicsDevice_.Viewport.Height / 2) - heroPos_.Y * zoomScale_);
            }
            spriteBatch_.Draw(backgroundTex_, tmpPos_, backgroundRec_, Color.White, 0f, Vector2.Zero, zoomScale_, SpriteEffects.None, 0f);
        }
        public void drawLegend()
        {
            spriteBatch_.Draw(blackTex_, Vector2.Zero, blackRec_, Color.White);
        }
        public void updateHeroPosition(Hero h)
        {
            heroPos_.X = h.getX() + 8;
            heroPos_.Y = h.getY() + 8;
        }
        public void drawSprite(ESprite eSprite, Vector2 textPos, SpriteEffects effectFlag = SpriteEffects.None)
        {
            spriteBatch_.Draw(spriteTex_, textPos, spriteRec_[eSprite][0], Color.White, 0f, Vector2.Zero, 2, effectFlag, 0f);
        }
        public void toggleCentering()
        {
            heroCentered_ = !heroCentered_;
        }
        public bool isHeroCentered()
        {
            return heroCentered_;
        }
        public void drawTitle()
        {
            tmpPos_.X = (graphicsDevice_.Viewport.Width / 2) - (titleRec_.Width * 2);
            tmpPos_.Y = (graphicsDevice_.Viewport.Height / 2) - (titleRec_.Height * 2);
            spriteBatch_.Draw(titleTex_, tmpPos_, titleRec_, Color.White, 0f, Vector2.Zero, 4, SpriteEffects.None, 0f);
        }
        public Vector2 getCenter()
        {
            tmpPos_.X = graphicsDevice_.Viewport.Width / 2;
            tmpPos_.Y = graphicsDevice_.Viewport.Height / 2;
            return tmpPos_;
        }
        public void zoomScaleInit()
        {
            zoomScale_ = 2;
        }
    }
}
