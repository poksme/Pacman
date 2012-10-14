using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class LevelManager
    {
        private String[,] maps =  {
                // LEVEL ONE
                {
                    "AAAAAAAAAAAAAAAAAAAAAAA",
                    "A                     A",
                    "A          S          A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A       EEE           A",
                    "A                     A",
                    "A                     A",
                    "AAAAAAAAAAAAAAAAAAAAAAAA"
                },
                // LEVEL TWO
                {
                    "AAAAAAAAAAAAAAAAAAAAAAA",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "AAAAAAAAAAAAAAAAAAAAAAAA"
                },
                // LEVEL THREE
                {
                    "AAAAAAAAAAAAAAAAAAAAAAA",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "A                     A",
                    "AAAAAAAAAAAAAAAAAAAAAAAA"
                }
            };
        Dictionary<char, Level.EBlocks> dictionary;

        public LevelManager()
        {
            dictionary = new Dictionary<char, Level.EBlocks>();
            dictionary.Add('A', Level.EBlocks.WALL);
            dictionary.Add('D', Level.EBlocks.DOOR);
            dictionary.Add(' ', Level.EBlocks.PIX);
            dictionary.Add('S', Level.EBlocks.SPAWN);
            dictionary.Add('E', Level.EBlocks.ENNEMY);
        }
        public Level.EBlocks getBlock(uint level, uint x, uint y)
        {
            return dictionary[maps[level, y].ToCharArray()[x]];
        }

        public int getLevelWidth(uint lvl)
        {
            return 17;
            //return maps[lvl, 0].Length;
        }

        public int getLevelHeight(uint lvl)
        {
            return 17;
            //return maps.GetLength((int)lvl);
        }
    }
}
