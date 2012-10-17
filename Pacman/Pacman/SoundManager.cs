using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Pacman
{
    class SoundManager
    {
        private ContentManager content;
        public enum ESound { CHOMP, BEGIN }
        private Dictionary<ESound, SoundEffect> sounds;

        public SoundManager(ContentManager c)
        {
            content = c;
            sounds = new Dictionary<ESound, SoundEffect>();
            sounds.Add(ESound.CHOMP, content.Load<SoundEffect>("pacman_chomp"));
            sounds.Add(ESound.BEGIN, content.Load<SoundEffect>("pacman_beginning"));
        }

        internal void play(ESound eSound)
        {
            sounds[eSound].Play();
        }
        internal void pause(ESound eSound)
        {
            sounds[eSound].Dispose();
        }
    }
}
