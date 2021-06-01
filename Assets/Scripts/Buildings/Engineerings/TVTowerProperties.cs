using System;
using UnityEngine;

namespace Buildings.Engineerings
{
    [Serializable]    
    public sealed class TVTowerProperties : EngineeringProperties
    {
        [SerializeField]
        internal int _Coverage;
        public int Coverage => _Coverage;

        public TVTowerProperties() : base() {
            _Coverage = 1;
        }
        public TVTowerProperties(string name, int cost, int coverage) : base(name, cost) {
            _Coverage = coverage;
        }

        public override string ToString()
        {
            return base.ToString() + $", Coverage:{_Coverage}";
        }
    }
}
