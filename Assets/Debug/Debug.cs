using System.Collections;
using System.Collections.Generic;
using System.IO;
using OpenRTS.Assets.Scripts.Buildings.Civils;
using UnityEngine;

namespace Assets.Debug {
    public class Debug : MonoBehaviour
    {
        public bool Enable = true;
        public GameObject b;
        // Start is called before the first frame update
        void Start()
        {
            enabled = Enable;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyUp(KeyCode.E)) {
                string json = JsonUtility.ToJson(b.GetComponent<House>());
                File.WriteAllText("./Assets/Resources/test.json", json);
            }
        }
    }
}