using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Pacman
{
    class SoundManager
    {
        private ContentManager content;
        public enum ESound { CHOMP, BEGIN, DEATH, EATGHOST, WIN, PAUSE}
        private Dictionary<ESound, SoundEffect> sounds;
        private SoundEffectInstance playing;
        public SoundManager(ContentManager c)
        {
            content = c;
            sounds = new Dictionary<ESound, SoundEffect>();
            sounds.Add(ESound.CHOMP, content.Load<SoundEffect>("pacman_chomp"));
            sounds.Add(ESound.BEGIN, content.Load<SoundEffect>("pacman_beginning"));
            sounds.Add(ESound.DEATH, content.Load<SoundEffect>("pacman_death"));
            sounds.Add(ESound.EATGHOST, content.Load<SoundEffect>("pacman_eatghost"));
            sounds.Add(ESound.WIN, content.Load<SoundEffect>("pacman_win"));
            sounds.Add(ESound.PAUSE, content.Load<SoundEffect>("pacman_eatfruit"));
            playing = sounds[ESound.CHOMP].CreateInstance();
        }

        internal void play(ESound eSound)
        {
            playing.Stop();
            playing.Dispose();
            playing = sounds[eSound].CreateInstance();
            playing.Play();
        }
        internal void pause(ESound eSound)
        {
            playing.Pause();
        }
    }
}
