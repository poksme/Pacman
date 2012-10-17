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
        SpriteBatch sb;
        Texture2D sheet;
        Texture2D alphaSheet;
        Dictionary<SpriteManager.ESprite, Rectangle[]> sheetPos;
        Dictionary<char, Rectangle> font;
        Texture2D background;
        Rectangle bgPos;
        Vector2 pos = Vector2.Zero;
        GraphicsDevice device;
        ContentManager content;
        Vector2 pacPosition = Vector2.Zero;

        Texture2D blackTex;
        Rectangle blackRec;

        Texture2D titleTex;
        Rectangle titleRec;

        private bool follow;

        protected float scale = 2f;
        public enum ESprite { PACUP, PACDOWN, PACLEFT, PACRIGHT, PACNEUTRAL, PIX, PALLETS, A, B, X, Y, START, 
        EYES_LEFT, EYES_RIGHT, EYES_DOWN, EYES_UP,
        BLINKYUP, BLINKYDOWN, BLINKYLEFT, BLINKYRIGHT, FRIGHTGHOST,
        INKYUP, INKYDOWN, INKYLEFT, INKYRIGHT,
        CLYDEUP, CLYDEDOWN, CLYDELEFT, CLYDERIGHT,
        PINKYUP, PINKYDOWN, PINKYLEFT, PINKYRIGHT };

        public SpriteManager(SpriteBatch spriteBatch, ContentManager c, GraphicsDevice gd)
        {
            sb = spriteBatch;
            content = c;
            device = gd;
            sheet = content.Load<Texture2D>("sprite_sheet");
            alphaSheet = content.Load<Texture2D>("pixelfont");
            sheetPos = new Dictionary<SpriteManager.ESprite, Rectangle[]>();
            font = new Dictionary<char, Rectangle>();
            follow = false;

            blackTex = new Texture2D(gd, 1, 1);
            blackTex.SetData(new Color[] { new Color(30, 30, 30, 225)  });
            blackRec = new Rectangle(0, 0, 200, 210);

            titleTex = content.Load<Texture2D>("Title");
            titleRec = new Rectangle(0, 0, 182, 34);
            #region DICTIONARY DEFINITIONS
            #region CHARACTERS
            sheetPos.Add(SpriteManager.ESprite.PACNEUTRAL, new Rectangle[] { new Rectangle(42, 2, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACLEFT, new Rectangle[] { new Rectangle(2, 2, 16, 16), new Rectangle(22, 2, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACRIGHT, new Rectangle[] { new Rectangle(2, 22, 16, 16), new Rectangle(22, 22, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACUP, new Rectangle[] { new Rectangle(2, 42, 16, 16), new Rectangle(22, 42, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACDOWN, new Rectangle[] { new Rectangle(2, 62, 16, 16), new Rectangle(22, 62, 16, 16) });

            sheetPos.Add(SpriteManager.ESprite.BLINKYUP, new Rectangle[] { new Rectangle(2, 82, 16, 16), new Rectangle(22, 82, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.BLINKYDOWN, new Rectangle[] { new Rectangle(42, 82, 16, 16), new Rectangle(62, 82, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.BLINKYLEFT, new Rectangle[] { new Rectangle(82, 82, 16, 16), new Rectangle(102, 82, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.BLINKYRIGHT, new Rectangle[] { new Rectangle(122, 82, 16, 16), new Rectangle(142, 82, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.FRIGHTGHOST, new Rectangle[] { new Rectangle(2, 162, 16, 16), new Rectangle(22, 162, 16, 16) });

            sheetPos.Add(SpriteManager.ESprite.INKYUP, new Rectangle[] { new Rectangle(2, 122, 16, 16), new Rectangle(22, 122, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.INKYDOWN, new Rectangle[] { new Rectangle(42, 122, 16, 16), new Rectangle(62, 122, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.INKYLEFT, new Rectangle[] { new Rectangle(82, 122, 16, 16), new Rectangle(102, 122, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.INKYRIGHT, new Rectangle[] { new Rectangle(122, 122, 16, 16), new Rectangle(142, 122, 16, 16) });

            sheetPos.Add(SpriteManager.ESprite.CLYDEUP, new Rectangle[] { new Rectangle(2, 142, 16, 16), new Rectangle(22, 142, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.CLYDEDOWN, new Rectangle[] { new Rectangle(42, 142, 16, 16), new Rectangle(62, 142, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.CLYDELEFT, new Rectangle[] { new Rectangle(82, 142, 16, 16), new Rectangle(102, 142, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.CLYDERIGHT, new Rectangle[] { new Rectangle(122, 142, 16, 16), new Rectangle(142, 142, 16, 16) });

            sheetPos.Add(SpriteManager.ESprite.PINKYUP, new Rectangle[] { new Rectangle(2, 102, 16, 16), new Rectangle(22, 102, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PINKYDOWN, new Rectangle[] { new Rectangle(42, 102, 16, 16), new Rectangle(62, 102, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PINKYLEFT, new Rectangle[] { new Rectangle(82, 102, 16, 16), new Rectangle(102, 102, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PINKYRIGHT, new Rectangle[] { new Rectangle(122, 102, 16, 16), new Rectangle(142, 102, 16, 16) });

            sheetPos.Add(SpriteManager.ESprite.EYES_LEFT, new Rectangle[] { new Rectangle(42, 202, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.EYES_RIGHT, new Rectangle[] { new Rectangle(62, 202, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.EYES_UP, new Rectangle[] { new Rectangle(2, 202, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.EYES_DOWN, new Rectangle[] { new Rectangle(22, 202, 16, 16) });
            #endregion

            #region LOOT
            sheetPos.Add(SpriteManager.ESprite.PIX, new Rectangle[] { new Rectangle(42, 22, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PALLETS, new Rectangle[] { new Rectangle(42, 42, 16, 16) });
            #endregion

            #region BUTTONS
            sheetPos.Add(SpriteManager.ESprite.A, new Rectangle[] { new Rectangle(142, 262, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.B, new Rectangle[] { new Rectangle(162, 262, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.X, new Rectangle[] { new Rectangle(102, 262, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.Y, new Rectangle[] { new Rectangle(122, 262, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.START, new Rectangle[] { new Rectangle(182, 262, 16, 16) });
            #endregion
            #endregion

            #region FONT DEFINITION
            char[] tmp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!-".ToCharArray();
            int it = 0;
            foreach (char cr in tmp)
            {
                font.Add(cr, new Rectangle(it * 8, 7, 8, 7));
                it++;
            }
            tmp = "0123456789() ".ToCharArray();
            it = 0;
            foreach (char cr in tmp)
            {
                font.Add(cr, new Rectangle(it * 8, 0, 8, 7));
                it++;
            }
            #endregion
            background = content.Load<Texture2D>("background");
            bgPos = new Rectangle(0, 0, 224, 288);
        }

        public void begin()
        {
            sb.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.Default, null, null, Matrix.Identity);
        }

        public void end()
        {
            sb.End();
        }

        public void drawAtIt(uint x, uint y, SpriteManager.ESprite b)
        {
            //pos.X = (x * 8 - 4) * scale;
            //pos.Y = (y * 8 + 20) * scale;

            //if (bgPos.Width * scale < device.Viewport.Height )
            if (!follow)
            {
                pos.X = (x * 8 - 4) * scale + ((device.Viewport.Width + blackRec.Width) / 2) - (bgPos.Width / 2) * scale;
                pos.Y = (y * 8 + 20) * scale + (device.Viewport.Height / 2) - (bgPos.Height / 2) * scale;
            }
            else
            {
                pos.X = (x * 8 - 4) * scale + ((device.Viewport.Width + blackRec.Width) / 2) - pacPosition.X * scale;
                pos.Y = (y * 8 + 20) * scale + (device.Viewport.Height / 2) - pacPosition.Y * scale;
            }
            sb.Draw(sheet, pos, sheetPos[b][0], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public void drawSprite(Sprite sp)
        {
            if (sp.drawn == false)
            {
                //sp.pos.X *= scale;
                //sp.pos.Y *= scale;
                //pos.X = sp.pos.X + ((device.Viewport.Width - blackRec.Width) / 2) - (sheetPos[sp.id][Math.Min(sp.step, sheetPos[sp.id].Length - 1)].Width / 2) * scale;
                //pos.Y = sp.pos.Y + (device.Viewport.Height / 2) - (sheetPos[sp.id][Math.Min(sp.step, sheetPos[sp.id].Length - 1)].Height / 2) * scale;

                //if (bgPos.Width * scale < device.Viewport.Height )
                if (!follow)
                {
                    pos.X = sp.pos.X * scale + ((device.Viewport.Width + blackRec.Width) / 2) - (bgPos.Width / 2) * scale;
                    pos.Y = sp.pos.Y * scale + (device.Viewport.Height / 2) - (bgPos.Height / 2) * scale;
                }
                else
                {
                    pos.X = sp.pos.X * scale + ((device.Viewport.Width + blackRec.Width) / 2) - pacPosition.X * scale;
                    pos.Y = sp.pos.Y * scale + (device.Viewport.Height / 2) - pacPosition.Y * scale;
                }
                sb.Draw(sheet, pos, sheetPos[sp.id][Math.Min(sp.step, sheetPos[sp.id].Length - 1)], Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
                sp.drawn = true;
            }
        }

        public void zoomIn()
        {
            if (scale < 6)
                scale *= 1.01f;
            else
                scale = 6;
        }

        public void zoomOut()
        {
            if (scale > 2)
                scale *= 0.99f;
            else
                scale = 2;
        }

        public void drawText(String s, Vector2 pos)
        {
            char[] tmp = s.ToUpper().ToCharArray();
            foreach (char c in tmp)
            {
                sb.Draw(alphaSheet, pos, font[c], Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
                pos.X += font[c].Width * 2; 
            }
        }

        public void centerDrawText(String s, int xOffset = 0, int yOffset = 0)
        {
            drawText(s, new Vector2(device.Viewport.Width / 2 - (8 * s.Length) + xOffset, device.Viewport.Height / 2 - 3 + yOffset));
        }

        public void drawBackground()
        {
            //if (bgPos.Width * scale < device.Viewport.Height )
            if (!follow)
            {
                pos.X = ((device.Viewport.Width + blackRec.Width) / 2) - (bgPos.Width / 2) * scale;
                pos.Y = (device.Viewport.Height / 2) - (bgPos.Height / 2) * scale;
            }
            else
            {
                pos.X = (((device.Viewport.Width + blackRec.Width) / 2) - pacPosition.X * scale);
                pos.Y = ((device.Viewport.Height / 2) - pacPosition.Y * scale);
            }
            sb.Draw(background, pos, bgPos, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
        }

        public void drawLegend()
        {
            sb.Draw(blackTex, Vector2.Zero, blackRec, Color.White);
        }

        public void update(Hero h)
        {
            pacPosition.X = h.getX() + 8;
            pacPosition.Y = h.getY() + 8;
        }

        internal void vanillaDraw(ESprite eSprite, Vector2 textPos, SpriteEffects effectFlag = SpriteEffects.None)
        {
            sb.Draw(sheet, textPos, sheetPos[eSprite][0], Color.White, 0f, Vector2.Zero, 2, effectFlag, 0f);
        }

        public void toggleFollow()
        {
            follow = !follow;
        }

        internal bool isFollowing()
        {
            return follow;
        }

        internal void drawTitle()
        {
            pos.X = (device.Viewport.Width / 2) - (titleRec.Width);
            pos.Y = (device.Viewport.Height / 2) - (titleRec.Height);
            sb.Draw(titleTex, pos, titleRec, Color.White, 0f, Vector2.Zero, 2, SpriteEffects.None, 0f);
        }

        internal Vector2 getCenter()
        {
            pos.X = device.Viewport.Width / 2;
            pos.Y = device.Viewport.Height / 2;
            return pos;
        }

        internal void scaleInit()
        {
            scale = 2;
        }
    }
}
