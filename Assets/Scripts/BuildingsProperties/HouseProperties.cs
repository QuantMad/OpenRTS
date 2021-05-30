using System;
using UnityEngine;

namespace Assembly_CSharp.Assets.Scripts.BuildingsProperties
{
    [Serializable]
    public class HouseProperties : CivilProperties
    {
        [SerializeField]
        internal int _Appartaments;
        public int Appartaments => _Appartaments;

        public HouseProperties() : base() {
            _Appartaments = 1;
        }
        public HouseProperties(string name, int cost, int appartaments) : base(name, cost)
        {
            _Appartaments = appartaments;
        }
    }
}
