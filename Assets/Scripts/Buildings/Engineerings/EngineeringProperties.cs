using System;

namespace Buildings.Engineerings
{
    [Serializable]
    public abstract class EngineeringProperties : BuildingProperties
    {
        public EngineeringProperties() : base() 
        {

        }
        public EngineeringProperties(string name, int cost) : base(name, cost)
        {
            
        }
    }
}
