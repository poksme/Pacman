using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class Sprite
    {
        public SpriteManager.ESprite id;
        public Vector2 pos;
        public Boolean drawn;
        public int step;

        public Sprite(Vector2 pos_, SpriteManager.ESprite id_)
        {
            id = id_;
            pos = pos_;
            drawn = false;
            step = 0;
        }
    }
}
