using BuildingsProperties.Engineerings;

namespace Buildings.Engineerings
{
    public class TVTower : Engineering
    {
        public TVTowerProperties TVTowerData => (TVTowerProperties) _BuildingData;
        public int Coverage => TVTowerData._Coverage;

        void Start()
        {
            _BuildingData = new TVTowerProperties();
        }
    }
}