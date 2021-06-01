using System;

namespace Buildings.Industrials
{
    [Serializable]
    public abstract class IndustrialProperties : BuildingProperties
    {
        public IndustrialProperties() : base() {

        }
        public IndustrialProperties(string name, int cost) : base(name, cost)
        {
            
        }
    }
}
