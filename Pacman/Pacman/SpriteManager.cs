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
        public enum ESprite { PACUP, PACDOWN, PACLEFT, PACRIGHT, PIX, PALLETS };

        public SpriteManager(SpriteBatch spriteBatch, ContentManager c)
        {
            sb = spriteBatch;
            content = c;
            sheet = content.Load<Texture2D>("sprite_sheet");
            background = content.Load<Texture2D>("background");
            sheetPos = new Dictionary<SpriteManager.ESprite, Rectangle[]>();
            sheetPos.Add(SpriteManager.ESprite.PACLEFT, new Rectangle[] { new Rectangle(2, 2, 16, 16), new Rectangle(22, 2, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PIX, new Rectangle[] { new Rectangle(42, 22, 16, 16) });
            sheetPos.Add(SpriteManager.ESprite.PALLETS, new Rectangle[] { new Rectangle(42, 42, 16, 16) });
            bgPos = new Rectangle(0, 0, 200, 200);
            //dictionary.Add(Level.EBlocks.WALL, new Rectangle[] {new Rectangle(2, 2, 8, 8)});
            //dictionary.Add(Level.EBlocks.DOOR, new Rectangle[] {new Rectangle(22, 2, 8, 8)});
            //dictionary.Add(Level.EBlocks.PIX, new Rectangle[] {new Rectangle(42, 2, 8, 8)});
            //dictionary.Add(Level.EBlocks.SPAWN, new Rectangle[] {new Rectangle(62, 2, 8, 8)});
            //dictionary.Add(Level.EBlocks.ENNEMY, new Rectangle[] {new Rectangle(82, 2, 8, 8)});
            //dictionary.Add(Level.EBlocks.EMPTY, new Rectangle[] { new Rectangle(2, 22, 8, 8) });
            //dictionary.Add(Level.EBlocks.PALLETS, new Rectangle[] { new Rectangle(22, 22, 8, 8) });
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
            pos.X = x * 8;
            pos.Y = y * 8;
            sb.Draw(sheet, pos, sheetPos[b][0], Color.White);
        }
        public void drawBackground()
        {
            sb.Draw(background, Vector2.Zero, bgPos, Color.White);
            //sb.Draw(background,null, null, Color.White);
        }
    }
}
