using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.StatesEnum;

namespace Assets.Scripts
{
    class ElevatorButton : abstractButton
    {
        private Text buttonText;

        private void Start()
        {
            buttonText = GetComponentInChildren<Text>();
        }

        public void setFloor(int onFloor)
        {
            base.numOfFloor = onFloor;
            base.state = ButtonState.Unpressed;
            buttonText = GetComponentInChildren<Text>();
            buttonText.text = onFloor.ToString();
        }

        new public void pressButton()
        {
            SendMessageUpwards("addToQueue", numOfFloor);
            base.buttonWorkDone();
        }

        new public void buttonWorkDone()
        {
            base.buttonWorkDone();
        }
    }
}
