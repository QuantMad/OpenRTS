using System;
using BuildingsProperties.Civils;
using UnityEngine;

namespace Buildings.Civils
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

        /*public override void ExportProperties(string path)
        {
            string json = JsonUtility.ToJson(HouseData);
            File.WriteAllText(path, json);
        }*/
    }
}