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
    protected GamePadState currentState;
    protected GamePadState lastState;
    private Boolean activated;

    public AScene (SceneManager scm, SpriteManager spm)
    {
        scm_ = scm;
        spm_ = spm;
    }
    public Boolean isActivated()
    {
        return activated;
    }
    public void activate()
    {
        activated = true;
    }

    public void desactivate()
    {
        activated = false;
    }

    abstract public void load();
    abstract public void update(GameTime gt);
    abstract public void draw();
    abstract public void unload();
    }
}
