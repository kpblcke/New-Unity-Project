using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    class GameViewManager : MonoBehaviour
    {
        public GameObject floorInterface;
        public GameObject elevatorInterface;
        public GameObject creatorInterface;

        void Start()
        {
            setActiveGenerator();
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }

        public void setActiveElevator()
        {
            setActiveInterface(elevatorInterface);
        }

        public void setActiveFloor()
        {
            setActiveInterface(floorInterface);
        }

        public void setActiveGenerator()
        {
            setActiveInterface(creatorInterface);
        }

        private void setActiveInterface(GameObject gameObject)
        {
            floorInterface.SetActive(false);
            creatorInterface.SetActive(false);

            gameObject.SetActive(true);
        }
    }
}
