using UnityEngine;

namespace Dadabases
{
    public class DatabaseBuildings : MonoBehaviour, IDataBase
    {
        void Start()
        {
            //TryLoadBuildings();
        }

        void Update()
        {
            
        }

        private bool TryLoadBuildings() {
            /*string path = "./Data/3-30-21B/3-30-21B.json";
            string json = File.ReadAllText(path);
            House h = JsonUtility.FromJson<House>(json);
            var go = Resources.Load<GameObject>(path);
            
            Debug.Log(json);*/
            return false;
        }
        
        public GameObject[] GetRecords() {
            return null;
        }
    }
}
