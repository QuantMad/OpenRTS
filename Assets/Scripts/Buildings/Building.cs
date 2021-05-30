using System;
using System.IO;
using Assembly_CSharp.Assets.Scripts.BuildingsProperties;
using UnityEngine;

namespace OpenRTS.Assets.Scripts.Buildings
{
    public abstract class Building : MonoBehaviour
    {
        internal BuildingProperties _BuildingData;
        public BuildingProperties BuildingData => _BuildingData;

        [SerializeField]
        private string Name = "Unnamed";

        [SerializeField]
        [Range(0, 999999)]
        private int Cost = 0;

        void Start()
        {
            _BuildingData = new BuildingProperties(Name, Cost);
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public virtual void ExportProperties(string path) {
            string json = JsonUtility.ToJson(_BuildingData);
            File.WriteAllText(path, json);
        }
    }
}