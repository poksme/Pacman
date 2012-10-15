using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class LevelManager
    {
        Rectangle wall = new Rectangle(0, 0, 8, 8);
        Rectangle pac = new Rectangle(0, 0, 8, 8);
        private char[][] maze =  new char[][]{
                // LEVEL ONE
                    "XXXXXXXXXXXXXXXXXXXXXXXXXXXX".ToCharArray(),
                    "X............XX............X".ToCharArray(),
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X".ToCharArray(),
                    "XOXXXX.XXXXX.XX.XXXXX.XXXXOX".ToCharArray(),
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X".ToCharArray(),
                    "X..........................X".ToCharArray(),
                    "X.XXXX.XX.XXXXXXXX.XX.XXXX.X".ToCharArray(),
                    "X.XXXX.XX.XXXXXXXX.XX.XXXX.X".ToCharArray(),
                    "X......XX....XX....XX......X".ToCharArray(),
                    "XXXXXX.XXXXX XX XXXXX.XXXXXX".ToCharArray(),
                    "XXXXXX.XXXXX XX XXXXX.XXXXXX".ToCharArray(),
                    "XXXXXX.XX          XX.XXXXXX".ToCharArray(),
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX".ToCharArray(),
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX".ToCharArray(),
                    "X     .   XXXXXXXX   .     X".ToCharArray(),
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX".ToCharArray(),
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX".ToCharArray(),
                    "XXXXXX.XX          XX.XXXXXX".ToCharArray(),
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX".ToCharArray(),
                    "XXXXXX.XX XXXXXXXX XX.XXXXXX".ToCharArray(),
                    "X............XX............X".ToCharArray(),
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X".ToCharArray(),
                    "X.XXXX.XXXXX.XX.XXXXX.XXXX.X".ToCharArray(),
                    "XO..XX.......  .......XX..OX".ToCharArray(),
                    "XXX.XX.XX.XXXXXXXX.XX.XX.XXX".ToCharArray(),
                    "XXX.XX.XX.XXXXXXXX.XX.XX.XXX".ToCharArray(),
                    "X......XX....XX....XX......X".ToCharArray(),
                    "X.XXXXXXXXXX.XX.XXXXXXXXXX.X".ToCharArray(),
                    "X.XXXXXXXXXX.XX.XXXXXXXXXX.X".ToCharArray(),
                    "X..........................X".ToCharArray(),
                    "XXXXXXXXXXXXXXXXXXXXXXXXXXXX".ToCharArray()
            };

        public LevelManager()
        {
            //dictionary = new Dictionary<char, Level.EBlocks>();
            //dictionary.Add('X', Level.EBlocks.WALL);
            //dictionary.Add('.', Level.EBlocks.PIX);
            //dictionary.Add(' ', Level.EBlocks.EMPTY);
            //dictionary.Add('O', Level.EBlocks.PALLETS);
            //dictionary.Add('S', Level.EBlocks.SPAWN);
            //dictionary.Add('E', Level.EBlocks.ENNEMY);
        }
        //public Level.EBlocks getBlock(uint level, uint x, uint y)
        //{
        //    return dictionary[maps[level][y].ToCharArray()[x]];
        //}

        public int getWidth()
        {
            return maze[0].Length;
        }

        public int getHeight()
        {
            return maze.Length;
        }

        public Boolean isPix(uint j, uint i)
        {
            return (maze[i][j] == '.');
        }
        public Boolean pixelIsPix(float x, float y)
        {
            return (maze[(uint)(y) / 8][(uint)(x) / 8] == '.');
        }

        public Boolean isPallet(uint j, uint i)
        {
            return (maze[i][j] == 'O');
        }
        public Boolean pixelIsPallet(float x, float y)
        {
            return (maze[(uint)(y) / 8][(uint)(x) / 8] == 'O');
        }


        public Boolean pixelIsWall(float x, float y)
        {
            return (maze[(uint)(y) / 8][(uint)(x) / 8] == 'X');
        }

        public Boolean isWall(uint j, uint i)
        {
            return (maze[i][j] == 'X');
        }

        public void eat(uint j, uint i)
        {
            maze[i][j] = ' ';
        }

        public void pixelEat(float x, float y)
        {
            if (maze[(uint)(y) / 8][(int)(x) / 8] == '.' || maze[(uint)(y) / 8][(int)(x) / 8] == 'O')
            maze[(uint)(y) / 8][(int)(x) / 8] = ' ';
        }
    }
}
