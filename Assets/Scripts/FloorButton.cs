using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assets.Scripts.StatesEnum;

namespace Assets.Scripts
{
    class FloorButton : abstractButton
    {
        public ButtonDirection buttonDirection;

        public FloorButton(ButtonDirection direction, int onFloor)
        {
            buttonDirection = direction;
            numOfFloor = onFloor;
        }

        new public void pressButton()
        {
            if (buttonDirection.Equals(ButtonDirection.Down))
            {
                SendMessageUpwards("addToDownQueue", numOfFloor);
            }
            if (buttonDirection.Equals(ButtonDirection.Up))
            {
                SendMessageUpwards("addToUpQueue", numOfFloor);
            }
        }
    }
}
