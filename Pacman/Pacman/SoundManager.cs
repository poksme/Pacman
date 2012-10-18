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
        public enum ESound { CHOMP, BEGIN, DEATH, EATGHOST, WIN, PAUSE, BGM}
        private Dictionary<ESound, SoundEffect> sounds;
        private SoundEffectInstance playing;
        private SoundEffectInstance bgm_;
        public SoundManager(ContentManager c)
        {
            content = c;
            sounds = new Dictionary<ESound, SoundEffect>();
            sounds.Add(ESound.CHOMP, content.Load<SoundEffect>("prive"));
            sounds.Add(ESound.BEGIN, content.Load<SoundEffect>("pacman_beginning"));
            sounds.Add(ESound.DEATH, content.Load<SoundEffect>("pacman_death"));
            sounds.Add(ESound.EATGHOST, content.Load<SoundEffect>("pacman_eatghost"));
            sounds.Add(ESound.WIN, content.Load<SoundEffect>("pacman_win"));
            sounds.Add(ESound.PAUSE, content.Load<SoundEffect>("pacman_eatfruit"));
            sounds.Add(ESound.BGM, content.Load<SoundEffect>("background music"));
            playing = sounds[ESound.CHOMP].CreateInstance();
            bgm_ = sounds[ESound.BGM].CreateInstance();
            bgm_.IsLooped = true;
        }

        internal void play(ESound eSound, float pitch = 0, float volume = 0.5f)
        {
            if (!playing.IsDisposed)
            {
                if (eSound == ESound.CHOMP && playing.State == SoundState.Playing)
                    return;
                playing.Stop();
                playing.Dispose();
            }
            playing = sounds[eSound].CreateInstance();
            playing.Pitch = pitch;
            playing.Volume = volume;
            playing.Play();
        }
        internal void bgmPause()
        {
            bgm_.Pause();
        }

        internal void stopPlaying()
        {
            if (!playing.IsDisposed)
            {
                playing.Stop();
                playing.Dispose();
            }
        }

        internal void bgmPlay()
        {
            bgm_.Play();
        }

        internal void setBgmPitch(float p)
        {
            bgm_.Pitch = p;
        }
    }
}
