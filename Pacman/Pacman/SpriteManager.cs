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
        Dictionary<SpriteManager.ESprite, Rectangle[]> sheetPos;
        Texture2D background;
        Rectangle bgPos;
        Vector2 pos = Vector2.Zero;
        ContentManager content;
        public enum ESprite { PACUP, PACDOWN, PACLEFT, PACRIGHT, PACNEUTRAL, PIX, PALLETS, A, B, X, Y };

        public SpriteManager(SpriteBatch spriteBatch, ContentManager c)
        {
            sb = spriteBatch;
            content = c;

            sheet = content.Load<Texture2D>("sprite_sheet");
            sheetPos = new Dictionary<SpriteManager.ESprite, Rectangle[]>();

            #region DICTIONARY DEFINITIONS
            #region ORIENTATION
            sheetPos.Add(SpriteManager.ESprite.PACNEUTRAL, new Rectangle[] { new Rectangle(42, 2, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACLEFT, new Rectangle[] { new Rectangle(2, 2, 16, 16), new Rectangle(22, 2, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACRIGHT, new Rectangle[] { new Rectangle(2, 22, 16, 16), new Rectangle(22, 22, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACUP, new Rectangle[] { new Rectangle(2, 42, 16, 16), new Rectangle(22, 42, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PACDOWN, new Rectangle[] { new Rectangle(2, 62, 16, 16), new Rectangle(22, 62, 16, 16) });
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
            #endregion
            #endregion

            background = content.Load<Texture2D>("background");
            bgPos = new Rectangle(0, 0, 224, 288);
        }

        public void begin()
        {
            sb.Begin();
        }

        public void end()
        {
            sb.End();
        }

        public void drawAtIt(uint x, uint y, SpriteManager.ESprite b)
        {
            pos.X = x * 8 - 4;
            pos.Y = y * 8 + 20;
            sb.Draw(sheet, pos, sheetPos[b][0], Color.White);
        }

        public void drawSprite(Sprite sp)
        {
            if (sp.drawn == false)
            {
                sb.Draw(sheet, sp.pos, sheetPos[sp.id][Math.Min(sp.step, sheetPos[sp.id].Length - 1)], Color.White);
                sp.drawn = true;
            }
        }

        public void drawBackground()
        {
            sb.Draw(background, Vector2.Zero, bgPos, Color.White);
        }
    }
}
