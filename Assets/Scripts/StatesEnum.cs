using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    class StatesEnum
    {
        public enum ElevatorState
        {
            Stop, Down, Up
        };

        public enum ButtonState
        {
            Unpressed, Pressed
        };

        public enum ButtonDirection
        {
            Up, Down
        };

        public enum QueueDirection
        {
            Up, Down
        };
    }
}
