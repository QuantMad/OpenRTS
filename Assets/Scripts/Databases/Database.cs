using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Databases
{
    public abstract class Database : MonoBehaviour
    {
        private const string RESOURCES_PATH = "./Assets/Resources/";

        public GameObject[] records 
        { 
            get; 
            internal set;
        }

        public int ItemsCount => records != null && records.Length > 0 ? records.Length : -1;

        public bool isEmpty => ItemsCount == - 1;

        internal void LoadItems<T>(string path) where T : MonoBehaviour, IDeserializable {
            List<GameObject> items = new List<GameObject>();
            string[] directories = Directory.GetDirectories(RESOURCES_PATH + path);
            foreach(string directory in directories) 
            {
                string name = directory.Substring(directory.LastIndexOf('/') + 1);
                var go = LoadObject<T>(path, name);
                items.Add(go);
            }
            records = items.ToArray();
        }

        internal virtual GameObject LoadObject<T>(string path, string name) where T : MonoBehaviour, IDeserializable
        {
            string resPath = $"{path}/{name}/{name}";
            UnityEngine.Object rawObject = Resources.Load(resPath);
            GameObject item = 
                (GameObject) Instantiate(rawObject, new Vector3(0, 0, 0), Quaternion.identity);
            item.SetActive(false);
            item.transform.parent = transform;

            return item;
        }

        internal string loadJson(string path, string name) {
            return File.ReadAllText($"{RESOURCES_PATH}/{path}/{name}/{name}_data.json");
        }
    }
}
