using System;
using BuildingsProperties;
using UnityEngine;

namespace Buildings
{
    public abstract class Building : MonoBehaviour
    {
        internal BuildingProperties _BuildingData;
        public BuildingProperties BuildingData => _BuildingData;
        public abstract void SetProperties(string json);
    }
}