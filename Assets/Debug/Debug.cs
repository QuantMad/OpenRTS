using System.IO;
using Buildings.Civils;
using UnityEngine;

namespace Assets.Debug {
    public class Debug : MonoBehaviour
    {
        public bool Enable = true;
        public GameObject building;
        // Start is called before the first frame update
        void Start()
        {
            enabled = Enable;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E)) {
                /*var house = building.GetComponent<House>();
                //house.ExportProperties($"./Data/3-30-21B/3-30-21B.json");

                string json = JsonUtility.ToJson(house._BuildingData);
                File.WriteAllText("./Data/test.json", json);*/
            }
        }
    }
}