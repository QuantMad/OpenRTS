using System;

namespace BuildingsProperties
{
    [Serializable]
    public class CivilProperties : BuildingProperties
    {
        public CivilProperties() : base() {

        }
        public CivilProperties(string name, int cost) : base(name, cost)
        {
            
        }
    }
}
