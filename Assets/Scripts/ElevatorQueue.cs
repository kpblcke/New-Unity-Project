using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static Assets.Scripts.StatesEnum;

namespace Assets.Scripts
{
    class ElevatorQueue : MonoBehaviour
    {
        public List<int> downQueue;
        public List<int> upQueue;
        public QueueDirection queueDirection;

        private void Start()
        {
            downQueue = new List<int>();
            upQueue = new List<int>();
            queueDirection = QueueDirection.Up;
        }

        public bool isEmpty()
        {
            return downQueue.Count() == 0 && upQueue.Count == 0;
        }

        public void addToDownQueue(int addFloor)
        {
            if (downQueue.Contains(addFloor))
            {
                return;
            }
            downQueue.Add(addFloor);
            Debug.Log("add down:" + addFloor);
        }

        public void addToUpQueue(int addFloor)
        {
            if (upQueue.Contains(addFloor))
            {
                return;
            }
            upQueue.Add(addFloor);
            Debug.Log("add up:" + addFloor);
        }

        public void removeFromQueue(int removeFloor)
        {
            downQueue.Remove(removeFloor);
            upQueue.Remove(removeFloor);
        }

        public void addToQueue(int addFloor)
        {
            addToUpQueue(addFloor);
            addToDownQueue(addFloor);
        }

    }
}
