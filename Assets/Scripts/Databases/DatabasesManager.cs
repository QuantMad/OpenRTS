using Buildings.Civils;
using UnityEngine;

namespace Databases
{
    public class DatabasesManager : MonoBehaviour 
    {
        public DatabaseBuildings Civils;
        
        void Start() {
            Civils = gameObject.AddComponent<DatabaseBuildings>();
            Civils.LoadItems<House>("Buildings/Civil/Houses");
        }
    }
}