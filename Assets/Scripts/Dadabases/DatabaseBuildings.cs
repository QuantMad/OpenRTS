using UnityEngine;

namespace OpenRTS.Assets.Scripts.Dadabases
{
    public class DatabaseBuildings : MonoBehaviour, IDataBase
    {
        void Start()
        {
            
        }

        void Update()
        {
            
        }

        public string GetName() {
            return "Building database finded";
        }
        
        public GameObject[] GetRecords() {
            return null;
        }
    }
}
