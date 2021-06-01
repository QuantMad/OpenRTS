namespace Buildings.Engineerings
{
    public abstract class Engineering<P> : Building<P> where P : EngineeringProperties
    {
        //public new EngineeringProperties BuildingData => (EngineeringProperties) _BuildingData;
    }
}