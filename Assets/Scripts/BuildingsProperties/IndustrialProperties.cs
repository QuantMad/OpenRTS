using System;

namespace BuildingsProperties
{
    [Serializable]
    public class IndustrialProperties : BuildingProperties
    {
        public IndustrialProperties() : base() {

        }
        public IndustrialProperties(string name, int cost) : base(name, cost)
        {
            
        }
    }
}
