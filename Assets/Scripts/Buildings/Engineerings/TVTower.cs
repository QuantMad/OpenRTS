namespace Buildings.Engineerings
{
    public sealed class TVTower : Engineering<TVTowerProperties>
    {
        //public new TVTowerProperties BuildingData => (TVTowerProperties) _BuildingData;

        //public TVTowerProperties TVTowerData => (TVTowerProperties) _BuildingData;
        //public int Coverage => TVTowerData._Coverage;

        void Start()
        {
            //_BuildingData = new TVTowerProperties();
        }

        /*public override void SetProperties(string json)
        {
            _BuildingData = JsonUtility.FromJson<TVTowerProperties>(json);
        }*/
    }
}