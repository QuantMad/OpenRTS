namespace Buildings.Civils
{
    public abstract class Civil<P> : Building<P> where P : CivilProperties
    {
        //public new CivilProperties BuildingData => (CivilProperties)_BuildingData;
        /*public virtual new CivilProperties BP {
            get {return (CivilProperties) _BuildingData; }
            set { }
        }*/
    }
}