using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pacman
{
    abstract class AScene
    {
    protected SceneManager scm_;
    protected SpriteManager spm_;
    protected SoundManager som_;
    protected GamePadState currentState;
    protected GamePadState lastState;
    private Boolean activated;

    public AScene(SceneManager scm, SpriteManager spm, SoundManager som)
    {
        scm_ = scm;
        spm_ = spm;
        som_ = som;
    }
    public Boolean isActivated()
    {
        return activated;
    }
    virtual public void activate()
    {
        activated = true;
    }

    virtual public void desactivate()
    {
        activated = false;
    }

    abstract public void load();
    abstract public void update(GameTime gt);
    abstract public void draw();
    abstract public void unload();
    }
}
