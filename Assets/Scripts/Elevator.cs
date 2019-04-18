using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.StatesEnum;

namespace Assets.Scripts
{
    class Elevator : MonoBehaviour
    {
        private int floorNum;
        public Doors doors;
        private List<ElevatorButton> elevatorButtons = new List<ElevatorButton>();

        private void Start()
        {
        }

        private Elevator()
        {

        }

        public Elevator(int floorNums)
        {
            floorNum = floorNums;
        }

        public int onFloorNum
        {
            get => floorNum;
            set => floorNum = value;
        }

        public void initDoors(Doors newDoors)
        {
            doors = newDoors;
        }

        public void openDoors()
        {
            doors.setOpen();
        }

        public void closeDoors()
        {
            doors.setClosed();
        }

        public void addElevatorButton(ElevatorButton newButton)
        {
            elevatorButtons.Add(newButton);
        }

        public void moveTo(int newFloor)
        {
            int upOrDown = newFloor.CompareTo(floorNum);
            if (upOrDown == 0)
            {
                stopMoving();
                return;
            }
            if (upOrDown < 0)
            {
                moveDown();
            } 
            else
            {
                moveUp();
            }
            floorNum = newFloor;
        }

        public void moveUp()
        {
            floorNum++;
        }

        public void moveDown()
        {
            floorNum--;
        }

        public void stopMoving()
        {
        }

        public bool isDoorOpen()
        {
            return doors.isDoorOpen();
        }
    }
}
