using System;
using System.IO;
using Buildings;
using Buildings.Civils;
using UnityEngine;

namespace Dadabases
{
    public class DatabaseBuildings : MonoBehaviour, IDataBase
    {
        void Start()
        {
            GameObject[] houses = TryLoadBuildings<House>("Buildings/Civil/House");
        }

        void Update()
        {
            
        }

        private GameObject[] TryLoadBuildings<T>(string path) where T : Building {
            string[] folders = Directory.GetDirectories($"./Assets/Resources/{path}/");
            GameObject[] buildings = new GameObject[folders.Length];

            string name;
            GameObject building;
            foreach(string folder in folders) {
                name = folder.Substring(folder.LastIndexOf('/') + 1);
                string resource = $"{path}/{name}/{name}";

                UnityEngine.Object prefab = Resources.Load(resource);
                building = (GameObject) Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
                building.SetActive(false);

                // Load json
                var p2 = $"{folder}/{name}_data.json";
                string json = File.ReadAllText(p2);
                
                building.AddComponent<T>().SetProperties(json);
                Debug.Log(building.GetComponent<T>().BuildingData.ToString());
            }

            return buildings;
        }
        
        public GameObject[] GetRecords() {
            return null;
        }
    }
}
