using System;
using UnityEngine;

namespace BuildingsProperties.Engineerings
{
    [Serializable]    
    public class TVTowerProperties : BuildingProperties
    {
        [SerializeField]
        internal int _Coverage;
        public int Coverage => _Coverage;

        public TVTowerProperties() : base() {
            BuildingType = BuildingTypes.House;
            _Coverage = 1;
        }
        public TVTowerProperties(string name, int cost, int coverage) : base(name, cost) {
            BuildingType = BuildingTypes.House;
            _Coverage = coverage;
        }
    }
}
