using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Pacman
{
    class LevelManager
    {
        private char[][] maze;

        public LevelManager()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("Pacman.map.txt")))
                {
                    String[] tmp = Regex.Split(sr.ReadToEnd(), "\r\n");
                    maze = new char[tmp.Length][];
                    for (int i = 0; i < tmp.Length; ++i)
                        maze[i] = tmp[i].ToCharArray();
                }
            }
            catch (Exception e)
            {
                Console.Write("The file could not be read :");
                throw e;                
            }
        }

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
