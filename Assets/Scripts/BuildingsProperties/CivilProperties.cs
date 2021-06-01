using System;

namespace BuildingsProperties
{
    [Serializable]
    public abstract class CivilProperties : BuildingProperties
    {
        public CivilProperties() : base() {

        }

        public CivilProperties(string name, int cost) : base(name, cost)
        {
            
        }
    }
}
