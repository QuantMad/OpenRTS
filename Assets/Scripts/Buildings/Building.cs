using System;
using UnityEngine;

namespace Buildings
{
    public abstract class Building<P> : SuperBuilding where P : BuildingProperties
    {
        [SerializeField]
        internal P _BuildingData;
        public virtual P BuildingData => _BuildingData;
        public override void SetProperties(string json) {
            _BuildingData = JsonUtility.FromJson<P>(json);
        }
    }
}