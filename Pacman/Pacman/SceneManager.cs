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
        public enum EScene { LEGEND, LEVEL, PAUSE };

        //VARS
        private Dictionary <EScene, AScene> scenes;
        private SpriteManager spm_;

        public SceneManager(SpriteManager spm)
        {
            scenes = new Dictionary<EScene,AScene>();
            scenes.Add(EScene.LEVEL, new Play(this, spm));
            scenes.Add(EScene.PAUSE, new Pause(this, spm));
            scenes.Add(EScene.LEGEND, new Legend(this, spm));
            spm_ = spm;
            scenes[EScene.LEVEL].activate();
            scenes[EScene.LEGEND].activate();
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

    }
}
