using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    class SceneManager
    {
        //DEFINITION
        public enum EScene {TITLE, LEGEND, LEVEL, PAUSE, WIN };

        //VARS
        private Dictionary <EScene, AScene> scenes;
        private SpriteManager spm_;
        private SoundManager som_;
        protected GamePadState currentState;
        protected GamePadState lastState;
        private bool exit_;

        public SceneManager(SpriteManager spm, SoundManager som)
        {
            scenes = new Dictionary<EScene,AScene>();
            scenes.Add(EScene.LEVEL, new Play(this, spm, som));
            scenes.Add(EScene.PAUSE, new Pause(this, spm, som));
            scenes.Add(EScene.LEGEND, new Legend(this, spm, som));
            scenes.Add(EScene.TITLE, new TitleScreen(this, spm, som));
            scenes.Add(EScene.WIN, new WinScreen(this, spm, som));
            spm_ = spm;
            som_ = som;
            activateScene(EScene.TITLE);
            exit_ = false;
            lastState = GamePad.GetState(PlayerIndex.One);
            currentState = GamePad.GetState(PlayerIndex.One);
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
