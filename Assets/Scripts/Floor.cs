using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    class Floor : MonoBehaviour, IComparable
    {
        private int floorNumber;
        public Text floorText;
        public FloorButton upFloorButton;
        public FloorButton downFloorButton;

        void Start()
        {
            floorText = GetComponentInChildren<Text>();
            upFloorButton.buttonDirection = StatesEnum.ButtonDirection.Up;
            downFloorButton.buttonDirection = StatesEnum.ButtonDirection.Down;
        }

        public int getFloorNumber()
        {
            return floorNumber;
        }

        public void setFloorNumber(int floorNum)
        {
            floorNumber = floorNum;
            upFloorButton.numOfFloor = floorNum;
            downFloorButton.numOfFloor = floorNum;
            floorText.text = "Этаж :" + floorNum;
        }

        public void setTopFloorButtons()
        {
            upFloorButton.gameObject.SetActive(false);
        }

        public void setFirstFloorButtons()
        {
            downFloorButton.gameObject.SetActive(false);
        }

        public int CompareTo(object obj)
        {
            Floor compareFloor = obj as Floor;
            if (compareFloor is null)
            {
                throw new Exception("Невозможно сравнить два объекта");
            }

            return floorNumber.CompareTo(compareFloor.floorNumber);
        }
    }
}
