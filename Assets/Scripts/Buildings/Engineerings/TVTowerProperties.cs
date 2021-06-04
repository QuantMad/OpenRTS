using System;
using UnityEngine;

namespace Buildings.Engineerings
{
    [Serializable]    
    public sealed class TVTowerProperties : EngineeringProperties
    {
        [SerializeField]
        internal int _coverage;
        public int Coverage => _coverage;

        public TVTowerProperties() : base() 
        {
            _coverage = 1;
        }
        public TVTowerProperties(string name, int cost, int coverage) : base(name, cost) 
        {
            _coverage = coverage;
        }

        public override string ToString()
        {
            return base.ToString() + $", Coverage:{_coverage}";
        }
    }
}
