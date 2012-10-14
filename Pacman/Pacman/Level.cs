using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Level : AScene
    {
        public enum EBlocks {PIX, DOOR, WALL, ENNEMY, SPAWN };
        private uint lvl;
        private LevelManager lm;

        public Level(SceneManager sm, SpriteManager spm, uint level) : base(sm, spm)
        {
            lvl = level;
            lm = new LevelManager();
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

        }
        private void drawMap()
        {
            for (uint i = 0; i < lm.getLevelHeight(lvl); ++i)
                for (uint j = 0; j < lm.getLevelWidth(lvl); ++j)
                    spm_.drawAtIt(j, i, lm.getBlock(lvl, j, i));
        }

        public override void draw()
        {
            drawMap();
        }

        public override void unload()
        {

        }
    }
}
