using System;

namespace Buildings.Civils
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
