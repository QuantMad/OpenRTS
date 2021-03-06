using System;
using UnityEngine;

namespace BuildingsProperties
{
    [Serializable]
    public class BuildingProperties 
    {
        [SerializeField]
        internal string _Name;
        public string Name => _Name;

        [SerializeField]
        internal int _Cost;
        public int Cost => _Cost;

        public BuildingProperties() {
            _Name = "Unnamed";
            _Cost = 0;
        }

        public BuildingProperties(string name, int cost) {
            _Name = name;
            _Cost = cost;
        }
    }
}
