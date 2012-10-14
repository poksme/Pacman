using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pacman
{
    class LevelManager
    {
        private String[][] maps =  new String[][]{
                // LEVEL ONE
                new string[] {
                    "XXXXXXXXXXXXXXXXXXXXXXXXXXXX",
                    "X............XX............X",
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X",
                    "XOXXXX.XXXXX.XX.XXXXX.XXXXOX",
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X",
                    "X..........................X",
                    "X.XXXX.XX.XXXXXXXX.XX.XXXX.X",
                    "X.XXXX.XX.XXXXXXXX.XX.XXXX.X",
                    "X......XX....XX....XX......X",
                    "XXXXXX.XXXXX XX XXXXX.XXXX X",
                    "XXXXXX.XXXXX XX XXXXX.XXXXXX",
                    "XXXXXX.XX          XX.XXXXXX",
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX",
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX",
                    "X     .   XXXXXXXX   .     X",
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX",
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX",
                    "XXXXXX.XX          XX.XXXXXX",
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX",
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX",
                    "X............XX............X",
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X",
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X",
                    "XO..XX.......  .......XX..OX",
                    "XXX.XX.XX.XXXXXXXX.XX.XX.XXX",
                    "XXX.XX.XX.XXXXXXXX.XX.XX.XXX",
                    "X......XX....XX....XX......X",
                    "X.XXXXXXXXXX.XX.XXXXXXXXXX.X",
                    "X.XXXXXXXXXX.XX.XXXXXXXXXX.X",
                    "X..........................X",
                    "XXXXXXXXXXXXXXXXXXXXXXXXXXXX"
                },
                // LEVEL TWO
                new string[] {
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
                new string[] {
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
            dictionary.Add('X', Level.EBlocks.WALL);
            dictionary.Add('.', Level.EBlocks.PIX);
            dictionary.Add(' ', Level.EBlocks.EMPTY);
            dictionary.Add('O', Level.EBlocks.PALLETS);
            dictionary.Add('S', Level.EBlocks.SPAWN);
            dictionary.Add('E', Level.EBlocks.ENNEMY);
        }
        public Level.EBlocks getBlock(uint level, uint x, uint y)
        {
            return dictionary[maps[level][y].ToCharArray()[x]];
        }

        public int getLevelWidth(uint lvl)
        {
            return maps[lvl][0].Length;
            //return 17;
            //return maps[lvl, 0].Length;
        }

        public int getLevelHeight(uint lvl)
        {
            return maps[lvl].Length;
            //return 17;
            //return maps.GetLength((int)lvl);
        }
    }
}
