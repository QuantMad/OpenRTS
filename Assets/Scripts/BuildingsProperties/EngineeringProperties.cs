using System;

namespace BuildingsProperties
{
    [Serializable]
    public class EngineeringProperties : BuildingProperties
    {
        public EngineeringProperties() : base() {

        }
        public EngineeringProperties(string name, int cost) : base(name, cost)
        {
            
        }
    }
}
