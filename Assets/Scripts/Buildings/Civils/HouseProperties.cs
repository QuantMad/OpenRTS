using System;
using UnityEngine;

namespace Buildings.Civils
{
    [Serializable]
    public sealed class HouseProperties : CivilProperties
    {
        [SerializeField]
        internal int _appartaments;
        public int Appartaments => _appartaments;

        public HouseProperties() : base() 
        {
            _appartaments = 1;
        }
        public HouseProperties(string name, int cost, int appartaments) : base(name, cost) 
        {
            _appartaments = appartaments;
        }

        public override string ToString()
        {
            return base.ToString() + $", Appartaments:{_appartaments}";
        }
    }
}
