using Assets.Scripts.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.HouseGenerator
{
    class HouseGenerator : MonoBehaviour
    {
        public InputField inputNumOfFloors;
        public ElevatorManager elevatorManager;
        public FloorsManager floorsManager;
        public Text errorText;
        private GameViewManager gameView;

        void Start()
        {
            inputNumOfFloors = GetComponentInChildren<InputField>();
            gameView = FindObjectOfType<GameViewManager>();
        }

        public void GenerateHouse()
        {
            int result = 0;
            if (int.TryParse(inputNumOfFloors.text, out result) && result > 0)
            {
                floorsManager.createFloors(result);
                elevatorManager.createNewElevator(result);
                elevatorManager.enabled = true;
                gameView.setActiveElevator();
            } 
            else
            {
                errorText.text = "Введено неверное количество этажей";
            }
        }
    }
}
