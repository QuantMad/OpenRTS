using System;
using UnityEngine;

namespace Buildings.Civils
{
    [Serializable]
    public class House : Civil<HouseProperties>
    {
        //public new HouseProperties BuildingData => (HouseProperties)_BuildingData;
        /*public virtual new HouseProperties BP {
            get {return (HouseProperties) _BuildingData; }
            set { }
        }*/
        //public HouseProperties HouseData => (HouseProperties) BuildingData;
        
        //[SerializeField]
        //[Range(1, 254)]
        //private byte Appartaments = 1;

        void Start()
        {
            //_BuildingData = new HouseProperties();
        }

        /*public override void SetProperties(string json)
        {
            _BuildingData = JsonUtility.FromJson<HouseProperties>(json);
        }*/
    }
}