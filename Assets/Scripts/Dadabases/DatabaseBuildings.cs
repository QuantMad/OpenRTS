using System.Collections.Generic;
using System.IO;
using Buildings;
using Buildings.Civils;
using UnityEngine;

namespace Dadabases
{
    public class DatabaseBuildings : MonoBehaviour, IDataBase
    {
        private Dictionary<string, GameObject> Civils = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> Engineerings;// = new Dictionary<string, GameObject>();
        private Dictionary<string, GameObject> Industrials;// = new Dictionary<string, GameObject>();
        
        void Start()
        {
            //string resource = "Buildings/Civil/House/3-30-21B";

            LoadBuildings<House>("Buildings/Civils", Civils);
        }

        private void LoadBuildings<B>(string path, Dictionary<string, GameObject> gos) where B : SuperBuilding { // Buildings/Civil/
            string[] dirs = Directory.GetDirectories("./Assets/Resources/"+path);
            foreach(string dir in dirs) {
                string name = dir.Substring(dir.LastIndexOf('/') + 1);
                var go = LoadBuilding<B>(path+"/"+name);
                gos.Add(name, go);
            }
        }

        private GameObject LoadBuilding<B>(string resource) where B : SuperBuilding {
            // Имя файла
            string name = resource.Substring(resource.LastIndexOf('/') + 1); 

            // Загрузка .fbx
            string p = $"{resource}/{name}";
            bool e = File.Exists(p+".fbx");
            UnityEngine.Object rawObject = Resources.Load(p);
            GameObject building = (GameObject) Instantiate(rawObject, new Vector3(0,0,0), Quaternion.identity);
            building.SetActive(false);
            building.transform.parent = transform;

            // Десериализация 
            string json = File.ReadAllText($"./Assets/Resources/{p}_data.json");
            building.AddComponent<B>().SetProperties(json);

            return building;
        }

        void Update()
        {
            
        }
        
        public GameObject[] GetRecords() {
            return null;
        }
    }
}
