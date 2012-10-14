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
        Dictionary<Level.EBlocks, Rectangle[]> dictionary;
        Vector2 pos = Vector2.Zero;
        ContentManager content;

        public SpriteManager(SpriteBatch spriteBatch, ContentManager c)
        {
            sb = spriteBatch;
            content = c;
            sheet = content.Load<Texture2D>("sprite_sheet");
            dictionary = new Dictionary<Level.EBlocks, Rectangle[]>();
            dictionary.Add(Level.EBlocks.WALL, new Rectangle[] {new Rectangle(2, 2, 16, 16)});
            dictionary.Add(Level.EBlocks.DOOR, new Rectangle[] {new Rectangle(22, 2, 16, 16)});
            dictionary.Add(Level.EBlocks.PIX, new Rectangle[] {new Rectangle(42, 2, 16, 16)});
            dictionary.Add(Level.EBlocks.SPAWN, new Rectangle[] {new Rectangle(62, 2, 16, 16)});
            dictionary.Add(Level.EBlocks.ENNEMY, new Rectangle[] {new Rectangle(82, 2, 16, 16)});
        }

        public void begin()
        {
            sb.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
        }

        public void end()
        {
            sb.End();
        }

        public void drawAtIt(uint x, uint y, Level.EBlocks b)
        {
            pos.X = x * 16;
            pos.Y = y * 16;
            sb.Draw(sheet, pos, dictionary[b][0], Color.White);
        }
    }
}
