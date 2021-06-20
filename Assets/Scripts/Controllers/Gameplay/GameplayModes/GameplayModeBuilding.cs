using System.Collections.Generic;
using Buildings.Civils;
using Dadabases;
using UnityEngine;

namespace Controllers.Gameplay.GameplayModes 
{
    [System.Serializable]
    public sealed class GameplayModeBuilding : GameplayMode
    {
        [SerializeField]
        private GameObject Database;
        private Dictionary<string, GameObject> _civils;
        void Start()
        {
            /*_civils = Database.GetComponent<DatabaseBuildings>().Civils;
            foreach(var b in _civils) {
                Debug.Log(b.Value.GetComponent<House>().ToString());
            }
            Debug.Log(_civils.Values.Count);*/
        }

        void OnEnable() {
            Debug.Log("Building mode activated");
        }

        void OnDisable()
        {
            Debug.Log("Building mode deactivated");
        }


        void Update()
        {
            
        }
    }
}