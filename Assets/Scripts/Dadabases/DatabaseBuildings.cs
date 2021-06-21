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
        private const string PATH_HOUSES = "Buildings/Civil/Houses";

        public bool IsEnable = false;
        public readonly Dictionary<string, GameObject> Civils = new Dictionary<string, GameObject>();
        void Start()
        {
            if (!IsEnable) return;

            LoadBuildings<House>(PATH_HOUSES, Civils);
        }

        private void LoadBuildings<B>(string path, Dictionary<string, GameObject> gos) where B : SuperBuilding 
        { 
            string[] buildingsDirectories = Directory.GetDirectories(RESOURCES_PATH + path);
            foreach(string directory in buildingsDirectories) 
            {
                string name = directory.Substring(directory.LastIndexOf('/') + 1);
                var go = LoadBuilding<B>(path, name);
                gos.Add(name, go);
            }
        }

        private GameObject LoadBuilding<B>(string path, string name) where B : SuperBuilding 
        {
            // Имя файла
            GameObject newBuilding = LoadObject(path, name);

            // Десериализация 
            string json = File.ReadAllText($"{RESOURCES_PATH}/{path}/{name}/{name}_data.json");
            newBuilding.AddComponent<B>().DeserializeProperties(json);
            Debug.Log($"Billding {name} type of {typeof(B).Name} loaded");
            var c = newBuilding.AddComponent<BoxCollider>();
            c.isTrigger = true;
            newBuilding.AddComponent<Rigidbody>().isKinematic = true;

            return newBuilding;
        }

        private GameObject LoadObject(string path, string name) {
            string resPath = $"{path}/{name}/{name}";
            UnityEngine.Object rawObject = Resources.Load(resPath);
            GameObject building = 
                (GameObject) Instantiate(rawObject, new Vector3(0,0,0), Quaternion.identity);
            building.SetActive(false);
            building.transform.parent = transform;

            return building;
        }
        
        public GameObject[] GetRecords() 
        {
            GameObject[] foos = new GameObject[Civils.Count];
            Civils.Values.CopyTo(foos, 0);
            return foos;
        }
    }
}
