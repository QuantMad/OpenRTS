using System.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace OpenRTS.Assets.Scripts.Buildings
{
    [XmlRootAttribute()]
    public abstract class Building : MonoBehaviour
    {
        [SerializeField]
        public string Name = "Undefined";
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}