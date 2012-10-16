using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace Pacman
{
    class InputManager
    {
        public enum EInputType { KEYBOARD, GAMEPAD, BOTH };
        public enum EInputButton { UP, DOWN, LEFT, RIGHT, A, B, X, Y, START, BACK } 
        EInputType type;
        //Dictionary<EInputButton, Boolean> previousState;
        Dictionary<EInputButton, Boolean> currentState;
        private GamePadState cur;

        public InputManager(EInputType t)
        {
            //previousState = new Dictionary<EInputButton, bool>();
            currentState = new Dictionary<EInputButton, bool>();
            foreach (EInputButton e in Enum.GetValues(typeof(EInputButton)))
            {
                //previousState[e] = false;
                currentState[e] = false;
            }
            type = EInputType.BOTH;
        }

        public Dictionary<EInputButton, Boolean> getState()
        {

            if (type == EInputType.GAMEPAD || type == EInputType.BOTH)
            {
                cur = GamePad.GetState(PlayerIndex.One);
            }
            if (type == EInputType.KEYBOARD || type == EInputType.BOTH)
            {

            }
            return currentState;
        }

        public void setType(EInputType t)
        {
            type = t;
        }
    }
}
