using System;
using BuildingsProperties.Engineerings;
using UnityEngine;

namespace Buildings.Engineerings
{
    public class TVTower : Engineering
    {
        public TVTowerProperties TVTowerData => (TVTowerProperties) _BuildingData;
        public int Coverage => TVTowerData._Coverage;

        void Start()
        {
            _BuildingData = new TVTowerProperties();
        }

        public override void SetProperties(string json)
        {
            _BuildingData = JsonUtility.FromJson<TVTowerProperties>(json);
        }
    }
}