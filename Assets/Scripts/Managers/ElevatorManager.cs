using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static Assets.Scripts.StatesEnum;

namespace Assets.Scripts
{
    class ElevatorManager : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public Transform ElevatorPanel;

        public ElevatorQueue queue;
        private ElevatorState lastElevatorMove;
        public Elevator elevator;
        public Text elevatorFloorText;
        public Text floorElevatorText;
        public float elevatorSpeed = 2f;

        void Start()
        {
            
        }

        void Update()
        {
        }

        void updateText()
        {
            String floorText = elevator.onFloorNum.ToString();

            if (!elevator.isDoorOpen() && !queue.isEmpty())
            {
                if (queue.queueDirection.Equals(QueueDirection.Down))
                {
                    floorText += "▼";
                }
                else
                {
                    floorText += "▲";
                }
            }
            elevatorFloorText.text = floorText;
            floorElevatorText.text = floorText;
        }

        public void createNewElevator(int numOfFloors)
        {
            elevator = GetComponentInChildren<Elevator>();
            elevator.onFloorNum = numOfFloors;
            for (int i = numOfFloors; i > 0; i--)
            {
                elevator.addElevatorButton(createButton(i));
            }
            elevator.onFloorNum = 1;
            
            queue = FindObjectOfType<ElevatorQueue>();
            gameObject.SetActive(true);
            InvokeRepeating("updateElevatorPosition", 0f, elevatorSpeed);
        }

        private void updateElevatorPosition()
        {
            updateText();
            if (elevator.isDoorOpen())
            {
                elevator.closeDoors();
                return;
            }

            if (queue.isEmpty())
            {
                return;
            }

            if ((queue.downQueue.Contains(elevator.onFloorNum) || queue.upQueue.Contains(elevator.onFloorNum)) && !elevator.isDoorOpen())
            {
                elevator.openDoors();
                queue.removeFromQueue(elevator.onFloorNum);
                return;
            }

            if (queue.queueDirection.Equals(QueueDirection.Up))
            {
                if (queue.upQueue.Count() != 0 && queue.upQueue.Max() > elevator.onFloorNum)
                {
                    elevator.moveUp();
                }
                else
                {
                    if (queue.downQueue.Max() > elevator.onFloorNum)
                    {
                        elevator.moveUp();
                    }
                    else
                    {
                        queue.queueDirection = QueueDirection.Down;
                    }
                }
            } 
            else
            {
                if (queue.downQueue.Count() != 0 && queue.downQueue.Min() < elevator.onFloorNum)
                {
                    elevator.moveDown();
                }
                else
                {
                    if (queue.upQueue.Min() < elevator.onFloorNum)
                    {
                        elevator.moveDown();
                    }
                    else
                    {
                        queue.queueDirection = QueueDirection.Up;
                    }
                }
            }
        }

        public void elevatorStop()
        {
            queue.upQueue.Clear();
            queue.downQueue.Clear();
        }

        private ElevatorButton createButton(int numOfFloors)
        {
            GameObject newButtonGameObject = GameObject.Instantiate(buttonPrefab, ElevatorPanel);
            ElevatorButton newButton = newButtonGameObject.GetComponentInChildren<ElevatorButton>();
            newButton.setFloor(numOfFloors);
            return newButton;
        }
    }
}
