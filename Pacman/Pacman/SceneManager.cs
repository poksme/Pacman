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
        //DEFINITION
        public enum EScene {TITLE, LEGEND, LEVEL, PAUSE };

        //VARS
        private Dictionary <EScene, AScene> scenes;
        private SpriteManager spm_;
        private bool exit_;

        public SceneManager(SpriteManager spm)
        {
            scenes = new Dictionary<EScene,AScene>();
            scenes.Add(EScene.LEVEL, new Play(this, spm));
            scenes.Add(EScene.PAUSE, new Pause(this, spm));
            scenes.Add(EScene.LEGEND, new Legend(this, spm));
            scenes.Add(EScene.TITLE, new TitleScreen(this, spm));
            spm_ = spm;
            scenes[EScene.TITLE].activate();
            exit_ = false;
            //scenes[EScene.LEVEL].activate();
            //scenes[EScene.LEGEND].activate();
        }

        public void draw()
        {
            spm_.begin();
            foreach (var pair in scenes)
                if (pair.Value.isActivated())
                    pair.Value.draw();
            spm_.end();
        }
        public void update(GameTime gt)
        {
            foreach (var pair in scenes)
                if (pair.Value.isActivated())
                    pair.Value.update(gt);
        }

        public void activateScene(EScene e)
        {
            if (e == EScene.LEVEL)
                scenes[EScene.LEGEND].activate();
            scenes[e].activate();
        }

        public void desactivateScene(EScene e)
        {
            scenes[e].desactivate();
        }
        public void desactivateAll()
        {
            foreach (var pair in scenes)
                pair.Value.desactivate();
        }


        internal void initScene(EScene e)
        {
            scenes[e].unload();
            scenes[e].load();
        }
        internal void exit()
        {
            exit_ = true;
        }

        internal bool isExiting()
        {
            return exit_;
        }

        public int getBonus()
        {
            return (scenes[EScene.LEVEL] as Play).getBonus();
        }
    }
}
