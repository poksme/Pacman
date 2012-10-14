using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class SceneManager
    {
        public enum EScene { LEVEL, PAUSE };

        // VARS
        private EScene it;
        private uint lvl;
        private AScene[] scenes;
        private SpriteManager spm_;

        public SceneManager(SpriteManager spm)
        {
            it = SceneManager.EScene.LEVEL;
            lvl = 0;
            scenes = new AScene[] { new Level(this, spm, lvl), new Pause(this, spm) };
            spm_ = spm;
        }

        public void draw()
        {
            spm_.begin();
            scenes[(uint)it].draw();
            spm_.end();
        }
        public void update(GameTime gt)
        {
            scenes[(uint)it].update(gt);
        }

        public void setScene(SceneManager.EScene n)
        {
            it = n;
        }

        public bool changeLevel(uint level)
        {
            Level tmp = (scenes[0] as Level);
            if (tmp != null)
            {
                tmp.setLevel(level);
                lvl = level;
                return true;
            }
            return false;
        }
    }
}
