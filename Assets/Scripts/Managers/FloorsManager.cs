using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    class FloorsManager : MonoBehaviour
    {
        public GameObject floorPrefab;
        public Transform floorsContainer;
        List<Floor> floors = new List<Floor>();

        private FloorsManager()
        {
        }

        public void createFloors(int numOfFloors)
        {
            for (int i = numOfFloors; i > 0; i--)
            {
                floors.Add(createFloor(i));
            }
            floors.Min().setFirstFloorButtons();
            floors.Max().setTopFloorButtons();
        }

        private Floor createFloor(int numOfFloor)
        {
            GameObject newFloorGameObject = GameObject.Instantiate(floorPrefab, floorsContainer);
            Floor newFloor = newFloorGameObject.GetComponent<Floor>();
            newFloor.setFloorNumber(numOfFloor);
            return newFloor;
        }
    }
}
