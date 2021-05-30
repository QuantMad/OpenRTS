using System;
using System.IO;
using Assembly_CSharp.Assets.Scripts.BuildingsProperties;
using UnityEngine;

namespace OpenRTS.Assets.Scripts.Buildings.Civils
{
    [Serializable]
    public class House : Civil
    {
        public HouseProperties HouseData => (HouseProperties) BuildingData;
        
        [SerializeField]
        [Range(1, 254)]
        private byte Appartaments = 1;

        void Start()
        {
            _BuildingData = new HouseProperties();
        }

        public override void ExportProperties(string path)
        {
            string json = JsonUtility.ToJson(HouseData);
            File.WriteAllText(path, json);
        }

        public void Import(House house) {

        }
    }
}