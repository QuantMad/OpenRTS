using System;

namespace Assembly_CSharp.Assets.Scripts.BuildingsProperties
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
