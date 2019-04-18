using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.StatesEnum;

namespace Assets.Scripts
{
    abstract class abstractButton : MonoBehaviour
    {
        private ButtonState buttonState;
        private int floorNum;
        
        protected abstractButton()
        {

        }

        public abstractButton(int onFloor)
        {
            numOfFloor = onFloor;
            state = ButtonState.Unpressed;
        }

        public int numOfFloor
        {
            get => floorNum;
            set => floorNum = value;
        }

        public ButtonState state
        {
            get => buttonState;
            set => buttonState = value;
        }

        public void pressButton()
        {
            buttonState = ButtonState.Pressed;
        }

        public void buttonWorkDone()
        {
            buttonState = ButtonState.Unpressed;
        }
    }
}
