using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    abstract class AScene
    {
    protected SceneManager scm_;
    protected SpriteManager spm_; 

    public AScene (SceneManager scm, SpriteManager spm)
    {
        scm_ = scm;
        spm_ = spm;
    }
    abstract public void load();
    abstract public void update(GameTime gt);
    abstract public void draw();
    abstract public void unload();
    }
}
