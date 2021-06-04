using System.Collections.Generic;
using System.IO;
using Buildings;
using Buildings.Civils;
using UnityEngine;

namespace Dadabases
{
    public class DatabaseBuildings : MonoBehaviour, IDataBase
    {
        private const string RESOURCES_PATH = "./Assets/Resources/";
        private string[] dbPatches = new string[] {
            "Buildings/Civil"
        };

        public bool IsEnable = false;
        private Dictionary<string, GameObject> _civils = new Dictionary<string, GameObject>();
        
        void Start()
        {
            if (!IsEnable) return;

            LoadBuildings<House>(dbPatches[0], _civils);
        }

        private void LoadBuildings<B>(string path, Dictionary<string, GameObject> gos) where B : SuperBuilding 
        { 
            string[] resourcesDirectories = Directory.GetDirectories(RESOURCES_PATH+path);
            foreach(string directory in resourcesDirectories) 
            {
                string name = directory.Substring(directory.LastIndexOf('/') + 1);
                var go = LoadBuilding<B>(path+"/"+name);
                gos.Add(name, go);
            }
        }

        private GameObject LoadBuilding<B>(string resource) where B : SuperBuilding 
        {
            // Имя файла
            string name = resource.Substring(resource.LastIndexOf('/') + 1); 

            // Загрузка .fbx
            string path = $"{resource}/{name}";
            UnityEngine.Object rawObject = Resources.Load(path);
            GameObject building = (GameObject) Instantiate(rawObject, new Vector3(0,0,0), Quaternion.identity);
            building.SetActive(false);
            building.transform.parent = transform;

            // Десериализация 
            string json = File.ReadAllText($"{RESOURCES_PATH}/{path}_data.json");
            building.AddComponent<B>().DeserializeProperties(json);

            return building;
        }
        
        public GameObject[] GetRecords() 
        {
            return null;
        }
    }
}
